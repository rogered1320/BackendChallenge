# Reto BCP

##Backend
- El backend fue construido con .net core y con base de datos sql server, ambos en un contenedor cada uno y orquestados por docker compose.
- Se utilizaron migrations y seeders para la data inicial.
- Se utilizo la autenticación por defecto de .net core, para generar usuarios grupos, etc. y poder usar  jwt.
- Se añadieron test unitarios para la prueba de lógica básica.
- Se utilizo Inyección de dependencias, para el desacoplamiento y fácil uso de las clases en los tests.

## Frontend
- El frontend esta hecho en Angular9, tiene una pantalla de inicio de sesión y otra de cálculo de tipo de cambio.


## ¿Cómo usarlo?
-  Dentro de la carpeta **..\BackendChallenge\PruebaBCP\PruebaBCP** tenemos un docker compose para ejecutarlo debemos ejecutar los siguientes comandos:
    `$ docker-compose build`
    `$ docker-compose up`
- Para probar el backend podemos hacer una llamada a la url [POST]http://localhost:8000/api/Auth para obtener un token, utilizando este payload

```json
{
    "Email": "admin",
    "Password": "Admin123@"
}
```

- Para hacer la prueba del tipo de cambio la url es [POST]http://localhost:8000/api/CurrencyExchangeCalculator
y podemos utilizar este payload de ejemplo 

````json
{
    "Amount": 100,
    "FromCurrency": "USD",
    "ToCurrency": "PEN"
}
```

- Para levantar el proyecto frontend es necesario entrar a la carpeta **..\BackendChallenge\Frontend\prueba-bcp-app** y ejecutar ng-serve (previamente se debe tener configurado angular)

