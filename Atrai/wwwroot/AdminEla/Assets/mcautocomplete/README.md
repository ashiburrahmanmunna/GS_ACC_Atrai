jQuery UI Multicolumn Autocomplete 2.2
======================================

Description
-----------
A simple extension for the jQuery UI autocomplete control that adds support for multiple columns in the drop-down list.
This plugin adds two additional options to the existing autocomplete control, **showHeader** and **columns**. These two options make it possible to display any number of columns in your autocomplete control.


How to use
----------
There are two demos included in the repository, demo1.html and demo2.html. demo1.html is a simple example and demo2.html is a more complext example using a json webservice as the datasource for the list.


As mentioned in the description above, there are only two options added to the autocomplete control.
- **showHeader**: A boolean that specifies whether or not to show a column header in the drop-down list.
- **columns**: An object array that defines the columns. See below for details on this option.

How to configure columns
------------------------
At the very least, your columns array must specify the **name**, which is the text shown in the header of the column, and the **minWidth**, which is the minimum width of the column.

So, if your widget's data source is an array of arrays then your code would look something like this.

	$("#search").mcautocomplete({
		showHeader: true,
		columns: [{ name: 'Make', minWidth: '100px' }, { name: 'Model', minWidth: '80px' }],
		source: [['Mustang', 'Ford'], ['Camero', 'Chevy'], ['Charger', 'Dodge']],
		select: function(event, ui) {
			// Sets the input to the 'Make' column when item is selected.
			this.value = (ui.item ? ui.item[0]: '');
			return false;
		}
	});

Another way to set up the widget would be to use an object array as the source. When that is the case then we must provide one additional property in the columns array. The **valueField** property tells the widget the name of the property to map to the column. 

Here is an example of using mcautocomplete with an object array as the data source.

	$("#search").mcautocomplete({
		showHeader: true,
		columns: [{ name: 'Make', minWidth: '100px', valueField: 'make' },
			{ name: 'Model', minWidth: '80px', valueField: 'model' }],
		source: [{ make: 'Mustang', model: 'Ford' }, { make: 'Camero', model: 'Chevy' }],
		select: function(event, ui) {
			// Sets the input to the 'Make' column when item is selected.
			this.value = (ui.item ? ui.item[0]: '');
			return false;
		}
	});
	
Links
-----
[jQuery UI autocomplete Demos and Documentation can be found here](http://jqueryui.com/demos/autocomplete/)

[View a simple working example of this plugin at JS Fiddle](http://jsfiddle.net/alforno/d3t7V/)

[View an example using a json webservice for data source at JS Fiddle](http://jsfiddle.net/alforno/g4stL/)
This example no longer works due to the dependant js webservice being removed or changed.