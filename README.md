empleo-dot-net
==============
[![Build status](https://ci.appveyor.com/api/projects/status/lmek7cwf3g8a2gk3/branch/master?svg=true)](https://ci.appveyor.com/project/amhed/empleo-dot-net/branch/master)

### What is this ?

The porpuse of this project is to bring a "real-in-production project" experiance for all developers interesting in learning ASP.Net MVC 5 and Xamarin.

This project is here thanks to the initiative of Developers.do and [C#.DO](https://www.facebook.com/groups/csharp.do/)

* Every now and then (mostly every 1 or 2 week) we'll have some virtual meetings ([Hangout](https://hangouts.google.com) or [Zoom](https://zoom.us)) to talk about any particular topic of
the project.
* The virtual meetings are commonly public, we schedule them and share the URL in the [Developers.do facebook group](https://www.facebook.com/groups/devdominicanos) and [Emplea.do's official twitter](https://twitter.com/emplea_do)
* During the meeting all viwers can bring their ideas, opinions and suggestions but bear in mind that they will be challenged so be ready to defend them
* All meetings are uploaded to [Youtube](http://youtube.com/c/Streamelopers) and added to [a playlist](https://www.youtube.com/playlist?list=PLW-4dWdTuQryzhz1YWfb-JLKmah1f5l1k)


### How can I collaborate
Because we love open source, this project is end-to-end open source and everyone can collaborate,
but even the most open source project has its rules, here are ours.
* You can check the project wiki [here](https://github.com/developersdo/empleo-dot-net/wiki)
* Start by watching the [recomended resources](https://github.com/developersdo/empleo-dot-net/wiki/Lista-de-Recursos-de-Aprendizaje);
* Watch our [previous sessions](https://www.youtube.com/channel/UCznWXigAvBa1ZtrgRmJGZgg)
* We use Gitflow workflow in combination of forking workflow for managing features and changes of the codebase . (To know more about git workflows follow this [link](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)
* If you see anything wrong feel free to create an [issue](https://github.com/developersdo/empleo-dot-net/issues)


#### Ready to code ?
checkout our [issues](https://github.com/developersdo/empleo-dot-net/issues) and start your pull request

If you are going to work with the Mobile App first run this:

    git update-index --assume-unchanged Mobile/Android/Resources/Resource.Designer.cs


##### Code guidelines
 - All variables, classes and methods will be named in english
 - We suggest you go and read these two books [The pragmatic programmer](http://goo.gl/A6r5am) and/or [Clean Code](http://goo.gl/uTRWnl), anyways someone will probably correct you during codereview so reading them is not 100% necessary.


### Pull request (PR)
Clone the repository solve an issue and create your pull request.

Make sure your cloned version of the repository is up to date.

Checkout the branch `develop`.

Create a feature branch. Remember to follow the convention of gitflow worflow for feature branches e.j. `feature/issueNumber-feature-name`.

Before pushing your branch make sure to do [an interactive rebase and squash your commits](http://gitready.com/advanced/2009/02/10/squashing-commits-with-rebase.html).

Push your branch and make the PR from that branch.

Make sure an issue related to the feature you are going to make already exists, if it doesn't, create the issue and wait for feedback.

If you make UI changes, include as many screenshots as possible. A before/after comparison is ideal, but showing the final look will suffice in most cases.

Before merging your pull request we do [code reviews](https://www.atlassian.com/agile/code-reviews).
Unless your pull request is a hotfix you will need at least 3 "thumbs up" reactions in order to merge it.
Getting the 3 thumbs up doesn't guarantee that your PR will be merged right away, be patient.

### Code Reviews

The best part of working on a open source project is that everybody can see your code, but don't be shy, if someone see something that
need to improve, they tell you, and you will get better.

You can also do code reviews, just go to a pull request, see the code and make your comments when you see something that can be improved,
if everything is ok you should add a "thumbs up" reaction.
Before starting code reviews checkout this [guidline](https://github.com/thoughtbot/guides/tree/master/code-review).

### Issues

Go to [Emplea.do](http://emplea.do) and if you see something that need to be fix or a new feature that you feel needs to be added,
don't be afraid and create the [issue](https://github.com/developersdo/empleo-dot-net/issues).
Before creating the new issue though, make sure that there is not another similar issue, if said issue exist go ahead and comment about your idea.

## Roadmap

### Scope
The scope of the project overall, looking at it as a platform is:
- We will only focus on Tech jobs (from techies to techies)
- Worldwide localization of said jobs, someone from DR should be able to eventually find a job in Spain or Argentina for example
- Easiness of distinction between onsite and remote jobs
- Posting should be simple, searching should be easy

All issues should fall into this scope, if an issue you propose is out of the scope then it will probably not be done but write it anyways, everything is open to conversation.

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

### Stage 4 - Polish and doing things right

* Test-Driven Development
* Dependency Injection
* User Stories that drive tests
