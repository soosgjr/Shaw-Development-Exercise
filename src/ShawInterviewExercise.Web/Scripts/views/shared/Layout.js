var sie = sie || {};
sie.views = sie.views || {};
sie.views.shared = sie.views.shared || {};

sie.views.shared.Layout = {};

sie.views.shared.Layout.hideLoader = function()
{
	$(".WrapperLoader").dialog("close");
};

sie.views.shared.Layout.showLoader = function()
{
	$(".WrapperLoader").dialog({
		closeOnEscape: false,
		draggable: false,
		modal: true,
		resizable: false,
		height: 160,
		width: 160
	});

	$(".ui-dialog-titlebar").hide();
};
