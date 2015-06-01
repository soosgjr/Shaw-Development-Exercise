var sie = sie || {};
sie.views = sie.views || {};
sie.views.showadmin = sie.views.showadmin || {};

sie.views.showadmin.Update = {};

sie.views.showadmin.Update._formSelector = null
sie.views.showadmin.Update._redirectUrl = null;

sie.views.showadmin.Update.initialize = function(formSelector, redirectUrl)
{
	var Update = sie.views.showadmin.Update;
	Update._formSelector = formSelector;
	Update._redirectUrl = redirectUrl;
	$(formSelector).submit(Update._handleSubmit)
	$(".Button").button();
};

sie.views.showadmin.Update._handleSubmit = function()
{
	var Update = sie.views.showadmin.Update;
	var form = $(Update._formSelector);

	if (form.valid())
	{
		sie.views.shared.Layout.showLoader();
		sie.net.ApiClient.updateShow(form.serialize(), Update._handleSuccess, Update._handleError)
	}

	return false;
};

sie.views.showadmin.Update._handleSuccess = function()
{
	sie.views.shared.Layout.hideLoader();
	window.location = sie.views.showadmin.Update._redirectUrl;
};

sie.views.showadmin.Update._handleError = function()
{
	sie.views.shared.Layout.hideLoader();
	alert("Failed to update the show.");
};
