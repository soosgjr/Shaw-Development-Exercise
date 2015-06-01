var sie = sie || {};
sie.views = sie.views || {};
sie.views.show = sie.views.show || {};

sie.views.show.Index = {};

sie.views.show.Index.showData = [];
sie.views.show.Index.showFilter = null;
sie.views.show.Index.showListSelector = null;

sie.views.show.Index.renderShows = function()
{
	var Index = sie.views.show.Index;
	var html = "";
	var showListSelector = Index.showListSelector;

	$(showListSelector + " *").off();
	$(showListSelector).html(html);
};
