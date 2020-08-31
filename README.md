# PortalCorreios
Solução para auxiliar no cálculos de rotas de encomendas 

O estado de San Andreas está atualizando o seu sistema postal e você foi designado para
desenvolver uma nova solução que calcule o caminho e o tempo de entrega das
encomendas postadas no estado.

San Andreas possui as seguintes cidades e condados:
 ```
 - Los Santos (LS)
 - San Fierro (SF)
 - Las Venturas (LV)
 - Red County (RC)
 - Whetstone (WS)
 - Bone County (BC)
 ```
 # Execução do Projeto 
- Pré Requisitos - SDK do .NET Core

-1º - Executar o projeto Portal Correios BackEnd
-2º - Realizar o upload do arquivo trechos:

#trechos.txt :
 ```
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
```

- 3º - Depois realziar o upload do arquivo 
#encomendas.txt :
```
 SF WS
 LS BC
 WS BC
```
  
A aplicação deverá gerar um arquivo de saída rotas.txt com o seguinte conteúdo:
  ``` 
  SF WS 1
  LS LV BC 2
  WS SF LV BC 5
  ```
