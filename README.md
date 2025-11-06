# FSM (Fantastic State Machine) vs. Arboles de decisiones
Una IA hecha con State Machine contra otra que hace exactamente lo mismo pero hecha en un Arbol de decisiones.
En este repositorio sin embargo estan todos los trabajo hechos hasta dia de hoy (5 de noviembre del 2025 en la clase de Inteligencia artificial 2 por el profesor Ion Sebastian Rodriguez Lara.
El trabajo en cuestion se encuentra en la carpeta de nombre "FSM Vs Arboles"

# Descripcion
Para esta entrega se eligio hacer la IA de "Mascota" o "Perro". Una IA con un comportamiento sencillo: Si el jugador se encuentra cerca, lo seguira constantemente, pero si se le abandona, regresara
a casa

# Procesamiento de la IA

La IA percibe siempre una cosa en ambos casos: que tan cerca esta el jugador. E incluso fuera de eso, ambas IAs funcionan practicamente igual. Cada una va a tomar el valor de la distancia entre ella
y el jugador. Si esta distancia esta por debajo o es igual al Threshold de "Distancia Maxima" la IA entrara ya sea a el estado o secuencia para seguir al jugador, tomando como objetivo el punto exacto
donde este este. Para evitar clipping, añadimos un simple offset para que siempre mantenga su distancia. 
Una vez la IA llegue a el punto denominado como su "Meta" esta contara ese estado o secuencia como completada y se pasara a "Idle". (En el caso de la maquina de estado, la IA tiene 2 tipos de Idle para
evitar errores.) En cuanto note que el jugador se movio, asignara una nueva meta cerca de el.
Si la distancia entre la IA y el jugador se vuelv demasiada, la IA entrara ya sea en el estado de "GoHome" o la secuencia del mismo nombre. Durante estos, primero se esperara unos segundos sin hacer nada
y despues marcara su "Meta" como un punto en el mapa denominado como "Home". Una vez ahi entrara a Idle nuevamente en espera de que el jugador se vuelva a acercar a ella.

#Dificultades: 

El state machine por la forma en la que lo hice tenia el problema que si solamente tenia un solo IdleState, podia dar errores pues se metia a idle tanto al quedarme quieto yo como al llegar
a la casa. Y como habia dos condiciones que eran igual de probables a la hora de tratar de sacarlo del idle state, podia dar un problema. Por ende acabe hacendo dos IdleStates, uno para cuando 
esta con el jugador y otro cuando esta esperando en la casa. De esta forma no habia choque de condiciones.

En el arbol la verdad todo me dio dificultad porque me hacia bolas muy facil sobre todo porque lo confundia con otros tipos de arboles que hemos visto, aparte de que tuve algunos errores porque 
algunas cosas se llamaban igual a otras de los StateMachine.

#En este caso que arquitectura funciona mejor y por que.

En mi opinion los StateMachine se me siguen haciendo mas faciles de entender incluso sin no soy lo mas proficiente con ellos. Sin embargo puedo reconocer que para este tipo de IAs tal vez los 
Arboles de Desicion son la opcion mas util, incluso si genuinamente siento que es algo de Overkill. Porque? Porque nos la dejan mas facil para escalarlos sin tener que pensar tanto en que las entradas
y salidas no conflictuen como las StateMachines.
Aun asi, me quedo con la FSM.

#Diagramas:

### FSM
![StateMachineDiagram](https://github.com/user-attachments/assets/f7232e38-7d1d-4591-bc7b-c9b620a77683)

### Arbol de desiciones
![StateMachineDiagram (1)](https://github.com/user-attachments/assets/6e1a2c7a-6ae4-45ad-9a72-e8a7222a2f8e)
