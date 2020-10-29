import * as msRest from "@azure/ms-rest-js";
import * as Models from "./models";
export declare class EmailerContext extends msRest.ServiceClient {
    /**
     * Initializes a new instance of the EmailerContext class.
     * @param [options] The parameter options
     */
    constructor(options?: Models.EmailerOptions);
}
