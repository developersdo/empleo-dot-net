empleo-dot-net 
==============
[![Build status](https://ci.appveyor.com/api/projects/status/lmek7cwf3g8a2gk3/branch/master?svg=true)](https://ci.appveyor.com/project/amhed/empleo-dot-net/branch/master)


### ¿Qué es esto?

Este proyecto tiene la finalidad de servir como fuente de aprendizaje sobre "desasrrollo en el mundo real" para los interesados en aprender ASP .NET MVC.

Es fruto de una iniciativa de Developers.DO y C#.DO.

* Cada 1 o 2 semanas crearemos un Hangout para explicar conceptos relacionados al desarrollo del proyecto. 
* El hangout será público, anunciaremos el URL con tiempo, y publicaremos un evento en Facebook para recordar a los interesados.
* Durante el hangout, no todos pueden participar en el video (hay un límite de 10 personas). Pero todos pueden colaborar en el widget de preguntas y respuestas.
* Durante las sesiones interactivas, todos están invitados a hacer preguntas en el chat. El propósito no es dar una cátedra, sino programar algo real y que los participantes aclaren dudas. 
* Luego de cada sesión se definirán Issues(feature nuevos, bugs, mejoras, etc.) para que todo el que quiera participar lo pueda hacer. 

### ¿Cómo Participo?

Todo el conocimiento y decisiones que surgen a partir de discusiones se asentará en [el wiki](https://github.com/developersdo/empleo-dot-net/wiki]], puede utilizarlo como referencia futura.

* Comienza revisando los [recursos sugeridos](https://github.com/developersdo/empleo-dot-net/wiki/Lista-de-Recursos-de-Aprendizaje)
* Mira la lista de [sesiones previas en Google Hangouts](https://github.com/developersdo/empleo-dot-net/wiki/Sesiones-de-Trabajo-Previas)
* Entra al [chat del grupo si tienes preguntas puntuales](https://devsdo.hipchat.com/invite/117666/9247d052e13262bf1488993e2d04b259) (Si ya tienes una cuenta en hipchat, [entra aquí como invitado](http://www.hipchat.com/g0PQNEPIJ)) 
* Si quieres colaborar puedes comenzar un [Pull Request](https://help.github.com/articles/using-pull-requests)

Tenemos un chat en Gitter: 
[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/developersdo/empleo-dot-net?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Roadmap

Pensamos dividir el desarrollo en tres etapas que permitan que participen personas con todo tipo de background en desarrollo:

#### Etapa 1 - Get it running

* Conceptos de git para desarrollo en equipo: forking, pull requests, merging, conflict resolution, etc
* Conceptos básicos de ASP.NET MVC
* Definición de historias de uso, ¿Qué debe lograr la aplicación?
* Definición de estructura básica MVC
* Entity Framework Code-First
* Viewmodels y renderización de vistas
* Adición de layer de seguridad

#### Etapa 2 - Refactorings

* Service Layer
* Patrones de diseño: 
  * Repository
  * Unit of Work
* Optimizaciones de HTML/CSS/JS
* Refactoring javascript
* Thin Controllers

#### Etapa 3 - Hacerlo de nuevo

* Test-Driven-Development
* Dependency Injection
* User Stories that drive tests
* Rewrite of the complete application 

#### Etapa 4 - Mobile Services

Una vez tengamos todo el código organizado y con pruebas unitarias desarrolladas, podremos exportar parte de la lógica a una aplicación mobile. Probablemente utilicemos [Xamarin Forms](xamarin.com/forms) para esta etapa del proyecto, porque implica que se puede desarrollar una sola aplicación y con esto llegar a las tres plataformas de smartphones principales:  iOS, Android y WP8.
