empleo-dot-net
==============
[![Build status](https://ci.appveyor.com/api/projects/status/lmek7cwf3g8a2gk3/branch/master?svg=true)](https://ci.appveyor.com/project/amhed/empleo-dot-net/branch/master)

### What is this ?

The porpuse of this project is to bring a "real-in-production project" experiance for all developers interesting in learning ASP.Net MVC 5 and Xamarin.

This project is here thanks to the initiative of Developers.do and [C#.DO](https://www.facebook.com/groups/csharp.do/)

* Each 1 or 2 week we'll have some virtual meetings ([Hangout](https://hangouts.google.com) or [Zoom](https://zoom.us)) to talk about a particulary topic of
the project.
* The virtual meetings are commonly public, we schedule it and share the URL, so interested people can join us.
* During the meeting all viwers can participate with they ideas, opinions and suggestions.
* All meetings all recorded and share on [Youtube](https://www.youtube.com/channel/UCznWXigAvBa1ZtrgRmJGZgg)  so others can see it even if they lost the meeting.
* After of each session we discuss about new issues, feeatures, bugs, etc, so everybody can participate.

If you are going to work with the Mobile App first run this:

    git update-index --assume-unchanged Mobile/Android/Resources/Resource.Designer.cs

### How can I collaborate
Because we love open source, this project is end-to-end open source and everyone can collaborate,
but even the most open source project has its rules, here are owers.

* Start by watching the [recomended resources](https://github.com/developersdo/empleo-dot-net/wiki/Lista-de-Recursos-de-Aprendizaje);
* Watch our [previous sessions](https://www.youtube.com/channel/UCznWXigAvBa1ZtrgRmJGZgg)
* We use Gitflow workflow in combination of forking workflow for managing features and changes of the codebase . (To know more about git workflows follow this [link](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)

#### Ready to code ?
checkout our [issues](https://github.com/developersdo/empleo-dot-net/issues) and start your pull request

### Pull request (PR)
Clone the repository, solve an issue and create your pull request.
Remember to follow the convention of gitflow worflow for feature branches e.j. `feature/issueNumber-feature-name`.
Try not to be a pirate, before working on an feature, make sure that an issue related with the feature exist, so you don't
brake the conventions.
Before merging your pull request we do [code reviews](https://www.atlassian.com/agile/code-reviews).
Unless your pull request is a hotfix you will need 3 +1 in order to merge it.

### Code Reviews

The best part of working on a open source project is that everybody can see your code, but don't be shy, if someone see something that
need to improve, they tell you, and you will get better.

You can also do code reviews, just go to a pull request, see the code and make your comments when you see something that can be improved,
if everything is ok you can add +1.
Before code review checkout this [guidline](https://github.com/thoughtbot/guides/tree/master/code-review).

### Issues

Go to [Emplea.do](http://emplea.do) and if you see something that need to be fix or a new feature need to be added,
don't be afraid and create the [issue](https://github.com/developersdo/empleo-dot-net/issues).
Before create the new issue, make sure that not exist this or any other similar issue, if the issue exist you can comment about your idea.


## Roadmap

### Stage 1 - Get it running

* Basics concepts of [git](https://try.github.io/levels/1/challenges/1) for team development, forking, pull request and others.
* Basics concepts of ASP.NET MVC.
* Use Case definitions (What should do the app?).
* Basics MVC structure.
* Entity Framework [Code-First](http://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx)
* Viewmodals and Views Rendering
* Security Layer

### State 2 - Refactorings

* [Design Patterns](https://sourcemaking.com/design_patterns).
* Service Layer
* Repository
* Unit of Work
* HTML/CSS/JS Optimizations
* JavaScript Refactoring
* Thin Controllers

### Stage 3 - Mobile App
* [Xamarin](https://www.xamarin.com)
* [JAD Sessions](https://www.youtube.com/watch?v=TK4NuTZWF1c)
* API Layer

### Stage 4 - Do it again

* Test-Driven Development
* Dependency Injection
* User Stories that drive tests
* Rewrite the entire application



