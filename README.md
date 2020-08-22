# TesteBarDg

1 - Banco de dados > sqlite3 > BarDg

2 - Tabelas e alimentacao:
  create table comandas (id integer not null primary key);
  insert into comandas(id) values (1), (2), (3), (4);
  create table itens (id integer not null primary key, nome text not null, valor real not null);
  insert into itens (id, nome, valor) values (1, ‘Cerveja’, 5), (2, ‘Conhaque’, 20), (3, ‘Suco’, 50), (4, ‘Água’, 70);
  create table compras (id integer not null primary key, idComanda integer not null, idItem integer not null, itemPromocional integer not null, foreign key(idComanda) references comandas(id), foreign key(idItem) references itens(id));
  
3 - Utilizar Entity para persistencia dos dados

4 - TesteBarDg > onde ficam controllers e conversao com front
    .Domain > onde ficam as classes de dominio ou conversao do processamento para entradas e saidas das requisicoes
    .Infra > onde fica o processamento e logica dos dados de entrada, o que precisa ser feito para devolver a devida saida.
    .Test > onde ficam os testes integrados da API

5 - Para o front, estou pensando em um html simples, com js bem estruturado, subindo um servidorzinho gulp.