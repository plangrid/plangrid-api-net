# PlanGrid .NET SDK for the public PlanGrid API

To install, use the Nuget [package](https://www.nuget.org/packages/PlanGrid.Api/):

    Install-Package PlanGrid.Api
	
## Details API Docs

For the fullblown documentation, head on over to [our developer site](https://developer.plangrid.com).
There you can get a description of every endpoint at your disposal and also
an explanation of basic concepts such as authentication and how to get an 
API token.

## Getting Started

Once installed, to access the api, simply use `PlanGridClient.Create()`.
However, you will need to provide your API key to gain access.  There are 
three ways to provide the key.  The simplest is to pass it directly as an
argument to `Create`:

    IPlanGridApi api = PlanGridClient.Create("yourapikey");
    
This has the advantage of being straightforward, but has the disadvantage of
baking the key into your code, which reduces security and makes it more 
difficult to update.
	
Alternatively, you can set the key in you `App.config` (or `Web.config`) file: 

    <appSettings>
        <add key="PlanGridApiKey" value="yourapikey" />
    </appSettings>

Ensure that you do not already have an `<appSettings>` node -- if you do, add 
the `<add />` element to the existing one.  When using this approach, you can
create the client with the parameterless constructor:

    IPlanGridApi api = PlanGridApiClient.Create();
    
Finally, you may set the key in an environment variable; the variable name 
must be `PLANGRIDAPIKEY`.

## Getting a list of projects

Having provided the API key in one of the ways outlined above, you can now
interact with the various endpoints available to you.  To start, we'll simply
get a list of projects:

    Page<Project> projects = await api.GetProjects();
    
Some things to note:
* This returns a paginated subset of all the projects to which you have access.
* The default limit is 50 projects
* To get the next 50, you'd pass 50 as the first argument (this value defaults to
0, implying that you want to start from the beginning). 

To get the next 20 projects (after the first 50), you would call:

    projects = await api.GetProjects(50, 20);

## Copyright

Copyright &copy; PlanGrid, Inc. MIT License; see LICENSE for further details.