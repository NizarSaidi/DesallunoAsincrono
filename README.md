# Desayuno Asíncrono
Experimentando con las funciones asíncronas y síncronas usando un ejercicio basa en la preparación de un desalluno

---

## Objetivo

Comprender la importancia del **diseño** en la preparación de un desayuno asíncrono y aprender a optimizar tiempos de ejecución.


---

## Descripción

Un desarrollador quiere automatizar la preparación de su desayuno. Cada acción tiene un tiempo de ejecución conocido. El problema es que el usuario tiene **poco tiempo por la mañana** y no puede esperar eternamente.

Tu trabajo es implementar diferentes enfoques de ejecución y descubrir cuál es el adecuado, **analizando por qué unos funcionan y otros no**.

> *"No se trata de correr más rápido, sino de saber qué carreras correr en paralelo."*


---

## Las 7 Acciones del Desayuno

| # | Acción | Tiempo | Descripción |
|---|--------|--------|-------------|
| 1 | Hacer café | 200ms | Encender la cafetera y esperar |
| 2 | Calentar sartén | 200ms | Poner el fuego y esperar a que esté caliente |
| 3 | Freír huevos | 300ms | Necesita la sartén caliente (acción 2) |
| 4 | Freír bacon | 300ms | Necesita la sartén caliente (acción 2) |
| 5 | Tostar pan | 200ms | Meter el pan en la tostadora |
| 6 | Untar mantequilla | 100ms | Necesita el pan tostado (acción 5) |
| 7 | Hacer zumo | 200ms | Exprimir las naranjas |

---

## Restricción

El usuario tiene un **tiempo límite de 500ms**. Si el desayuno no está listo a tiempo:

> ☕ **"¡El café se ha enfriado! Los huevos y tostadas con café frío no tienen gracia..."**

---

## Tabla de tiempos
| Ejecución |  Tiempo         | ¿Pasa la restriccion? |
|-----------------------|------------------------------------------------------|----------------|
| Secuencial      | 1.500~ms  | NO        |
|  Asíncrona |   530~ms  | SI         |
| Mas Optima   | 520~ms   | SI       |

## Diferencias Observadas

#### Secuencial
En la ejecución secuencial se ha observado una triplicación del tiempo necesario para realizar los métodos esto dado que no se pueden paralelizar las tareas observando un notorio aumento del tiempo requerido haciendo este modelo de ejecución bastante obsoleto.

#### Asíncrona con async/await
En la ejecución asíncrona usando async y await se ha observado una disminución notoria del tiempo requerido para la operación, las tareas que se han podido paralelizar han dado un gran impulsó a la bajada de tiempo siendo esto posible gracias a la ejecucion en paraleló de ciertas funciones.

---

#### Ejecución más optima
En la ejecución mas optima se ha retirado la paralelizacion en ciertas funciones que no eran necesarias ya que los tiks perdidos en paralelizar dichas funciones hacian retrasar la accion sumando un tiempo que se podia ahorrar consiguiendo munos milisegundos extra y haciendo la ejecucion mas rapida, aparte de este metodo tambien se ha usado el Task.Run para iniciar las tareas directamente sin usar el WhenAll ya que se ha observado que el tiempo requerido aumenta por las acciones intermedias que tenga que hacer este metodo, dando un no muy notorio aumento.

## ¿ Que acciones se pueden ejecutar a la ver y por que?

Se ha observado que se puede ejecutar de manera simultanea: 
|HacerCafe | CalentarSarten | TostarPan | HacerZumo|

Estas cuatro acciones no necesitan de ninguna otra previa para realizarse por lo que se pueden paralelizar

|FreirHuevo| FreirBacon | UntarMantequilla|

Estas en cambio si que necesitan de otras funciones para poder realizarse por lo que tienen que esperar a que acaben las anteriores para poder iniciar
sinembargo entre ellas pueden actuar de manera paralela ya que entre ella no se necesitan, y en este supuesto se asume que es una sarten muy grande por lo que los huevos y el bacon se pueden hacer a la ver.

## ¿ El enfoque con mayor rendimiento es el mas seguro?

En este caso es seguro, ya que no se ha realizado ningun tipo de uso de ejecuciones paralelas, por lo que es un metodo igual de seguro que el resto.

## ¿ Merece la pena complicarse optimizando los tiempos?

Si, merece la pena, uno de los puntos mas importantes como desarrollador es saber que lo que estamos realizando es profesional y se pueda sacar al mercado, de nada sirve realizar un proyecto si luego este no se puede usar, y una de las principales necesidades de un programa es que este actúe con rapidez, como hemos podido observar con antelación ,no realizar métodos de manera secuencial puede llegar el triplicar los tiempos de repuesta de nuestro programa y eso sin mencionar cuando se es necesario acciones de programas externos, un programa lento es un mal programa, y como dessarrollador no se puede permitir realizar malos programas, todo el tiempo dedicado en la optimización del programa es tiempo que el usuario se ahorra esperando a que este reaccione. 
