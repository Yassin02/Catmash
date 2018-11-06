# CatMash.Web

This folder is primarily a container for the top-level pieces of the application.

The following commands are needed to be added using The package manager Nuget so it generates the necessary files to build and load the application.

 - Install-Package jQuery -Version 3.3.1
 - Install-Package bootstrap -Version 4.1.3


## Basic Application Structure

    Controllers/       	# Global / application-level controllers

    Views/          	# Views and Layouts

    Content/          	# Style sheets that are automatically required
	Images/		# Asserts such as images
	

#### Controllers/

This folder contains the application's global controllers. These controllers are used for routing
and other activities that span all views.

This folder contains the application's (data) Model classes.

#### Views/

This folder contains the views. The following directory structure is recommended:

    Views/
        foo/                    # Some meaningful grouping of one or more views
            Foo.cshtml          # The view class
            

This structure helps keep these closely related classes together and easily identifiable in
most tabbed IDE's or text editors.


### Content/

Its contents are automatically required and included in builds. Each new CSS file should be added to the App_Start/BundelConfig.cs class


