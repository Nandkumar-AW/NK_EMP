var ClientMasterServiceModule = angular.module('ClientMasterServiceModule', ['CommonAppUtility'])
var jsonheaders = { 'headers': { 'accept': 'application/json;odata=verbose' } };

ClientMasterServiceModule.service('ClientMasterService', function ($http, CommonAppUtilityService) {


    this.PostData = function (option, Path) {

        return CommonAppUtilityService.CreateItem(Path, option);
    }

});