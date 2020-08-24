var MAIN = (function(){
    return{

        init: function(){
            MAIN.construirMenu();
        },

        construirMenu: function(){
            $.ajax({
                method: "GET",
                url: "https://localhost:5000/menu/lista-itens"
            })
            .done(function(retornoOK) {
                $("#itens_menu").html("");
                var novoItem;
                for(var i=0; i< retornoOK.length; i++)
                {
                    novoItem = document.createElement("LI");
                    novoItem.className = "list-group-item";
                    novoItem.id = retornoOK[i].id_item;
                    novoItem.innerText = retornoOK[i].nome_item + " - R$" + retornoOK[i].valor_item;
                    novoItem.dataset["preco"] = retornoOK[i].valor_item;
                    novoItem.click = MAIN.selecionarItem();
                }
                $("#itens_menu").append(novoItem);
            })
            .catch(function(retornoErro) {
                alert(JSON.stringify(retornoErro));
            });
        },

        selecionarItem: function(){
            $(this).siblings().removeClass("active");
            $(this).addClass("active");
        },

        efetuarCompra: function(){
            var entrada = {
                IdComanda: $("#comandaCliente").val(),
                IdItem: $("#itens_menu > .active").data("preco")
            };
            $.ajax({
                method: "POST",
                url: "https://localhost:5001/comanda/comprar",
                data: entrada
            })
            .done(function(retornoOK) {
                alert( retornoOK.mensagem );
            })
            .catch(function(retornoErro) {
                alert( JSON.stringify(retornoErro) );
            });
        },

        gerarExtrato: function(){
            $.ajax({
                method: "GET",
                url: "https://localhost:5001/comanda/2"
            })
            .done(function(retornoOK) {
                var novoItem;
                var itemPromocional;
                $("#itens_extrato").html("");
                for(var i=0; i< retornoOK.itens_comprados.length; i++)
                {
                    novoItem = document.createElement("LI");
                    novoItem.className = "list-group-item";
                    novoItem.id = retornoOK.itens_comprados[i].id_item;
                    if(retornoOK.itens_comprados[i].item_promocional == 1){
                        itemPromocional = document.createElement("SPAN");
                        itemPromocional.className = "badge badge-primary";
                        itemPromocional.innerText = retornoOK.itens_comprados[i].nome_item + " -R$" + retornoOK.itens_comprados[i].valor_item;
                        novoItem.appendChild(itemPromocional);
                    }else{
                        novoItem.innerText = retornoOK.itens_comprados[i].nome_item + " - R$" + retornoOK.itens_comprados[i].valor_item;
                    }
                    $("#itens_extrato").append(novoItem);
                }
                
                var totalDiv = document.createElement("DIV");
                totalDiv.className = "alert alert-primary";
                totalDiv.innerText = "Total a pagar: R$" + retornoOK.valor_total;

                novoItem = document.createElement("LI");
                novoItem.className = "list-group-item";
                novoItem.id = "total";
                novoItem.appendChild(totalDiv)
                $("#itens_extrato").append(novoItem);
            })
            .catch(function(retornoErro) {
                alert(JSON.stringify(retornoErro));
            });
        },

        resetarComanda: function(){
            $.ajax({
                method: "DELETE",
                url: "https://localhost:5001/comanda/limpar/" + $("#comandaCliente").val()
            })
            .done(function(retornoOK) {
                $("#itens_extrato").html("");
                alert(retornoOK.mensagem);
            })
            .catch(function(retornoErro) {
                alert(JSON.stringify(retornoErro));
            });
        }
    };
})();