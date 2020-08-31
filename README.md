# PortalCorreios
Solução para auxiliar no cálculos de rotas de encomendas 

O estado de San Andreas está atualizando o seu sistema postal e você foi designado para
desenvolver uma nova solução que calcule o caminho e o tempo de entrega das
encomendas postadas no estado.
  San Andreas possui as seguintes cidades e condados:
    - Los Santos (LS)
    - San Fierro (SF)
    - Las Venturas (LV)
    - Red County (RC)
    - Whetstone (WS)
    - Bone County (BC)
    
Os trechos disponíveis entre as cidades e condados são atualizados mensalmente, sendo
definidos através de um arquivo que além do trecho, informa o tempo em dias que cada
encomenda leva ao passar por ele. Cada trecho é unidirecional, podendo haver diferenças
entre o trecho de ida e volta, ou mesmo estar indisponível.

Por exemplo, se o trecho a partir de Los Santos até San Fierro levasse um dia e se o
caminho inverso levasse dois dias, no arquivo estaria representado da seguinte forma:
  LS SF 1
  SF LS 2
  
A sua tarefa é calcular a menor rota para as encomendas enviadas nas agências
postais do estado . Sua aplicação precisará receber, além do arquivo com a origem e
destino de cada encomenda, os trechos ativos no estado no momento e precisará escrever
em um arquivo de saída a rota com menor tempo disponível e o tempo para cada
encomenda.
  Dados o seguintes arquivos de exemplo:
#trechos.txt :
  LS SF 1
  SF LS 2
  LS LV 1
  LV LS 1
  SF LV 2
  LV SF 2
  LS RC 1
  RC LS 2
  SF WS 1
  WS SF 2
  LV BC 1
  BC LV 1
#encomendas.txt :
  SF WS
  LS BC
  WS BC
  
A aplicação deverá gerar um arquivo de saída rotas.txt com o seguinte conteúdo:
  SF WS 1
  LS LV BC 2
  WS SF LV BC 5
