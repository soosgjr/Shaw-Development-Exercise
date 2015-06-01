var sie = sie || {};
sie.views = sie.views || {};
sie.views.showadmin = sie.views.showadmin || {};

sie.views.showadmin.Index = {};

sie.views.showadmin.Index.deletionConfirmation = "Are you sure you want to delete this show?";

sie.views.showadmin.Index.initialize = function()
{
	$(".Button").button();
	$(".DeleteButton").click(sie.views.showadmin.Index._handleDeletion);
};

sie.views.showadmin.Index._handleDeletion = function()
{
	var Index = sie.views.showadmin.Index;
	var id;
	var item;

	if (window.confirm(Index.deletionConfirmation))
	{
		sie.views.shared.Layout.showLoader();
		id = $(this).attr("data-id");
		item = $(this).parent();
		sie.net.ApiClient.deleteShow(
			id,
			function()
			{
				sie.views.shared.Layout.hideLoader();
				item.hide("slow", function() { item.remove(); });
			},
			Index._handleError
		);
	}

	return false;
}

sie.views.showadmin.Index._handleSuccess = function()
{
};

sie.views.showadmin.Index._handleError = function()
{
	sie.views.shared.Layout.hideLoader();
	alert("Failed to delete the show.");
};
