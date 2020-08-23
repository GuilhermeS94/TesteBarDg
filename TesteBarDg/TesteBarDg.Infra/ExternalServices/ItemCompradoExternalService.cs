using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteBarDg.Domain.ExternalServices;
using TesteBarDg.Domain.ExternalServices.Models;
using TesteBarDg.Infra.Models;

namespace TesteBarDg.Infra.ExternalServices
{
    public class ItemCompradoExternalService : IItemCompradoExternalService
    {
        private readonly BarDgContext _barDgContext;

        public ItemCompradoExternalService(BarDgContext barDgContext)
        {
            _barDgContext = barDgContext;
        }

        public async Task<ItemCompradoResponse> ComprarItem(long idComanda, long idItem)
        {

            if (_barDgContext.Compras.Where(x => x.IdItem == 3).Count() > 3)
                throw new Exception("Não pode comprar mais do que 3 sucos.");

            Compras compra = new Compras();

            compra.Id = _barDgContext.Compras.Count() + 1;
            compra.IdComanda = idComanda;
            compra.IdItem = idItem;
            compra.ItemPromocional = 0;
            _barDgContext.Compras.Add(compra);
            _barDgContext.SaveChanges();

            CheckPromocaoAguaDeGraca(idComanda);
            CheckPromocaoCervejaeSuco(idComanda);

            return new ItemCompradoResponse
            {
                Sucesso = true,
                Mensagem = "Compra registrada com sucesso."
            };
        }

        private void CheckPromocaoCervejaeSuco(long idComanda)
        {
            bool baratearcerveja = false;

            var qtdCervejas = from compra in _barDgContext.Compras
                              where
                                  compra.IdComanda == idComanda &&
                                  compra.IdItem == 1 &&
                                  compra.ItemPromocional == 1
                              select compra;
            
            int qtdSucos = _barDgContext.Compras
            .Where(x => (x.IdComanda.Equals(idComanda)) && x.IdItem == 3)
            .Count();

            baratearcerveja = (qtdSucos > 0) && (qtdCervejas.Count() < qtdSucos);

            if (baratearcerveja)
            {
                Compras cerveja = _barDgContext.Compras
                .Where(x => x.IdComanda.Equals(idComanda) && (x.IdItem == 1 && x.ItemPromocional == 0)).First();
                cerveja.ItemPromocional = 1;
                _barDgContext.Compras.Update(cerveja);
                _barDgContext.SaveChanges();
            }
        }

        private void CheckPromocaoAguaDeGraca(long idComanda)
        {
            bool isAguadeGraca = false;

            var qtdCervejas = from compra in _barDgContext.Compras
            where
                compra.IdComanda == idComanda &&
                compra.IdItem == 1
            select compra;

            var qtdConhaques = from compra in _barDgContext.Compras
            where
                compra.IdComanda == idComanda &&
                compra.IdItem == 2
            select compra;

            var qtdAguasPromocionais = from compra in _barDgContext.Compras
            where
                compra.IdComanda == idComanda &&
                compra.IdItem == 2 &&
                compra.ItemPromocional == 1
            select compra;

            isAguadeGraca = (qtdCervejas.Count() >= 2 && qtdConhaques.Count() >= 3) &&
                            (qtdAguasPromocionais.Count() < ((qtdCervejas.Count() % 2) + (qtdConhaques.Count() % 3)));

            if (isAguadeGraca)
            {
                Compras agua = _barDgContext.Compras.Where(x => x.IdComanda.Equals(idComanda) && (x.IdItem == 4 && x.ItemPromocional == 0)).First();
                agua.ItemPromocional = 1;
                _barDgContext.Compras.Update(agua);
                _barDgContext.SaveChanges();
            }
        }
    }
}
