var sie = sie || {};
sie.views = sie.views || {};
sie.views.showadmin = sie.views.showadmin || {};

sie.views.showadmin.Create = {};

sie.views.showadmin.Create._formSelector = null
sie.views.showadmin.Create._redirectUrl = null;

sie.views.showadmin.Create.initialize = function(formSelector, redirectUrl)
{
	var Create = sie.views.showadmin.Create;
	Create._formSelector = formSelector;
	Create._redirectUrl = redirectUrl;
	$(formSelector).submit(Create._handleSubmit)
	$(".Button").button();
};

sie.views.showadmin.Create._handleSubmit = function()
{
	var Create = sie.views.showadmin.Create;
	var form = $(Create._formSelector);

	if (form.valid())
	{
		sie.views.shared.Layout.showLoader();
		sie.net.ApiClient.createShow(form.serialize(), Create._handleSuccess, Create._handleError)
	}

	return false;
};

sie.views.showadmin.Create._handleSuccess = function()
{
	sie.views.shared.Layout.hideLoader();
	window.location = sie.views.showadmin.Create._redirectUrl;
};

sie.views.showadmin.Create._handleError = function()
{
	sie.views.shared.Layout.hideLoader();
	alert("Failed to create the show.");
};
