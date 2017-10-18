( function( $ ) {
	$(document).ready(function(){

		// LNB Menu
		$("#cssmenu>ul>li.has-sub>a").click(function(){
			//slide up all the link lists
			$("#cssmenu ul ul").slideUp();
			//slide down the link list below the h3 clicked - only if its closed
			if(!$(this).next().is(":visible"))
			{
		  		$(this).next().slideDown();
			}
		});
		$('#cssmenu>ul>li.has-sub>a').append('<span class="holder"></span>');
		// //LNB Menu

	});
	
} )( jQuery );