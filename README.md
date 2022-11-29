# validadorBrasil
Validações de documentos, placas veiculares, cep e etc

### Importando os métodos
Os validadores são funções incorporadas no StringExstensions, portando para usá-lo é necessário importar o pacote
```CSharp
using validadorBrasil;
```

### Validando placa
```CSharp
string val = "AAA0000";

if(val.IsPlaca())
    Console.WriteLine(val + " é uma placa!");
else
    Console.WriteLine(val + " não é uma placa!");
```
Output:
````
AAA0000 é uma placa!
````

### Validando CPF
```CSharp
string val = "01010101010";

if(val.IsCPF())
    Console.WriteLine(val + " é um CPF!");
else
    Console.WriteLine(val + " não é um CPF!");
```
Output:
````
01010101010 não é um CPF!
````

### Validando CNPJ
```CSharp
string val = "22222222222222";

if(val.IsCNPJ())
    Console.WriteLine(val + " é um CNPJ!");
else
    Console.WriteLine(val + " não é um CNPJ!");
```
Output:
````
22222222222222 não é um CNPJ!
````
