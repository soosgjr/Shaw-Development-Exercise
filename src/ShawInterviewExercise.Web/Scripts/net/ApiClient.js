var sie = sie || {};
sie.net = sie.net || {};

sie.net.ApiClient = {};

sie.net.ApiClient.apiUrl = null;

sie.net.ApiClient.createShow = function(data, onSuccess, onError)
{
	var url = sie.net.ApiClient._generateUrl("api/show");
	$.ajax({
		url: url,
		data: data,
		type: "POST",
		success: onSuccess,
		error: onError
	});
};

sie.net.ApiClient.readAllShows = function(onSuccess, onError)
{
	var url = sie.net.ApiClient._generateUrl("api/show");
	$.ajax({
		url: url,
		type: "GET",
		success: onSuccess,
		error: onError
	});
};

sie.net.ApiClient.deleteShow = function(id, onSuccess, onError)
{
	var url = sie.net.ApiClient._generateUrl("api/show/" + id);
	$.ajax({
		url: url,
		type: "DELETE",
		success: onSuccess,
		error: onError
	});
};

sie.net.ApiClient.updateShow = function(data, onSuccess, onError)
{
	var url = sie.net.ApiClient._generateUrl("api/show");
	$.ajax({
		url: url,
		data: data,
		type: "PUT",
		success: onSuccess,
		error: onError
	});
};

sie.net.ApiClient._generateUrl = function(path)
{
	return sie.net.ApiClient.apiUrl + "/" + path;
};
