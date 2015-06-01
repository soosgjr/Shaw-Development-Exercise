var sie = sie || {};
sie.net = sie.net || {};

sie.net.ApiClient = {};

sie.net.ApiClient.apiUrl = null;

sie.net.ApiClient.readAllShows = function(onSuccess, onError)
{
	var url = sie.net.ApiClient._generateUrl("show/get");
	$.ajax({
		url: url,
		type: "GET",
		success: onSuccess,
		error: onError
	});
};

sie.net.ApiClient.deleteShow = function(id, onSuccess, onError)
{
	var url = sie.net.ApiClient._generateUrl("show/get/" + id);
	$.ajax({
		url: url,
		type: "DELETE",
		success: onSuccess,
		error: onError
	});
};

sie.net.ApiClient._generateUrl = function(path)
{
	return sie.net.ApiClient.apiUrl + "/" + path;
};
