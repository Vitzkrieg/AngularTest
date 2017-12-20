angular
    .module('myApp')
    .service('asyncDataService',
        [
            '$http', '$q',
            function ($http, $q) {
                var result = {
                    getDataFromUrl: function (url, showMsgOnError) {
                        return $http
                            .get(url)
                            .then(
                                //success
                                function (response) {
                                    // success callback
                                    return response.data;

                                },
                                //failure
                                function (data, status, headers, config) {
                                    console.log('asyncDataServiceGET error (data)', data);
                                    console.log('trace ', console.trace());
                                    return data;
                                });
                    },

                    postDataToUrl: function (url, postData) {
                        return $http.post(
                                url,
                                postData
                            )
                            .then(
                                //success
                                function (data, status, headers, config) {
                                    return data;

                                },
                                //failure
                                function (data, status, headers, config) {
                                    // called asynchronously if an error occurs
                                    // or server returns response with an error status.
                                    console.log('asyncDataServicePOST error (data)', data);
                                    console.log('trace ', console.trace());
                                    return data;

                                });
                    },
                    deleteDataToUrl: function (url, model) {

                        return $q(function (resolve, reject) {

                            $http.delete(url, model)
                                .success(function (data, status, headers, config) {

                                    resolve(data);

                                })
                                .error(function (data, status, headers, config) {
                                    // called asynchronously if an error occurs
                                    // or server returns response with an error status.
                                    console.log('asyncDataServiceDELETE error (data)', data);
                                    console.log('trace ', console.trace());
                                });
                        });
                    }
                };
                return result;
            }
        ]);
