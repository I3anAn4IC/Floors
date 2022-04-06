mergeInto(LibraryManager.library, {
	Hello: function(){
		window.alert("I'm a life!");
	},

	HelloString: function(str) {
		window.alert(Pointer_stringify(str));
	},
})