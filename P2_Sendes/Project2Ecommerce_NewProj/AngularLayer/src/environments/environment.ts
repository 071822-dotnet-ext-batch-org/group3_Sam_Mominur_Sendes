// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

//THIS IS AN IMPORT OF MY JSON FILE SINCE I COULDNT IMPORT IT THE REGULAR WAY
// const config = require("../../auth0_secrets.config.json");
// import * as config from "./config.json";
// const app = express();
// import {domain,clientId} from "../../auth0_secrets.config.json";
import auth from "../../auth0_secrets.config.json";
// import clientId from "../../auth0_secrets.config.json";

// import domain from '../../auth0_secrets.config.json'
// import {domain, clientId} from "package.json"
// const domain_ = domain
export const environment = {
  production: false ,
  auth
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.