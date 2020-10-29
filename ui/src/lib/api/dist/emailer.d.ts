import * as msRest from "@azure/ms-rest-js";
import * as Models from "./models";
import * as Mappers from "./models/mappers";
import { EmailerContext } from "./emailerContext";
declare class Emailer extends EmailerContext {
    /**
     * Initializes a new instance of the Emailer class.
     * @param [options] The parameter options
     */
    constructor(options?: Models.EmailerOptions);
    /**
     * @param [options] The optional parameters
     * @returns Promise<Models.GetCustomersResponse>
     */
    getCustomers(options?: msRest.RequestOptionsBase): Promise<Models.GetCustomersResponse>;
    /**
     * @param callback The callback
     */
    getCustomers(callback: msRest.ServiceCallback<Models.Customer[]>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    getCustomers(options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<Models.Customer[]>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<Models.AddCustomerResponse>
     */
    addCustomer(options?: Models.EmailerAddCustomerOptionalParams): Promise<Models.AddCustomerResponse>;
    /**
     * @param callback The callback
     */
    addCustomer(callback: msRest.ServiceCallback<Models.Customer>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    addCustomer(options: Models.EmailerAddCustomerOptionalParams, callback: msRest.ServiceCallback<Models.Customer>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<Models.UpdateCustomerResponse>
     */
    updateCustomer(options?: Models.EmailerUpdateCustomerOptionalParams): Promise<Models.UpdateCustomerResponse>;
    /**
     * @param callback The callback
     */
    updateCustomer(callback: msRest.ServiceCallback<Models.Customer>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    updateCustomer(options: Models.EmailerUpdateCustomerOptionalParams, callback: msRest.ServiceCallback<Models.Customer>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<msRest.RestResponse>
     */
    deleteCustomer(options?: Models.EmailerDeleteCustomerOptionalParams): Promise<msRest.RestResponse>;
    /**
     * @param callback The callback
     */
    deleteCustomer(callback: msRest.ServiceCallback<void>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    deleteCustomer(options: Models.EmailerDeleteCustomerOptionalParams, callback: msRest.ServiceCallback<void>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<Models.GetEmailBlastsResponse>
     */
    getEmailBlasts(options?: msRest.RequestOptionsBase): Promise<Models.GetEmailBlastsResponse>;
    /**
     * @param callback The callback
     */
    getEmailBlasts(callback: msRest.ServiceCallback<Models.EmailBlast[]>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    getEmailBlasts(options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<Models.EmailBlast[]>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<Models.AddEmailBlastResponse>
     */
    addEmailBlast(options?: Models.EmailerAddEmailBlastOptionalParams): Promise<Models.AddEmailBlastResponse>;
    /**
     * @param callback The callback
     */
    addEmailBlast(callback: msRest.ServiceCallback<Models.EmailBlast>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    addEmailBlast(options: Models.EmailerAddEmailBlastOptionalParams, callback: msRest.ServiceCallback<Models.EmailBlast>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<Models.UpdateEmailBlastResponse>
     */
    updateEmailBlast(options?: Models.EmailerUpdateEmailBlastOptionalParams): Promise<Models.UpdateEmailBlastResponse>;
    /**
     * @param callback The callback
     */
    updateEmailBlast(callback: msRest.ServiceCallback<Models.EmailBlast>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    updateEmailBlast(options: Models.EmailerUpdateEmailBlastOptionalParams, callback: msRest.ServiceCallback<Models.EmailBlast>): void;
    /**
     * @param id
     * @param [options] The optional parameters
     * @returns Promise<msRest.RestResponse>
     */
    deleteEmailBlast(id: string, options?: msRest.RequestOptionsBase): Promise<msRest.RestResponse>;
    /**
     * @param id
     * @param callback The callback
     */
    deleteEmailBlast(id: string, callback: msRest.ServiceCallback<void>): void;
    /**
     * @param id
     * @param options The optional parameters
     * @param callback The callback
     */
    deleteEmailBlast(id: string, options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<void>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<Models.GetEmailRecipientsResponse>
     */
    getEmailRecipients(options?: msRest.RequestOptionsBase): Promise<Models.GetEmailRecipientsResponse>;
    /**
     * @param callback The callback
     */
    getEmailRecipients(callback: msRest.ServiceCallback<Models.EmailRecipient[]>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    getEmailRecipients(options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<Models.EmailRecipient[]>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<Models.AddEmailRecipientResponse>
     */
    addEmailRecipient(options?: Models.EmailerAddEmailRecipientOptionalParams): Promise<Models.AddEmailRecipientResponse>;
    /**
     * @param callback The callback
     */
    addEmailRecipient(callback: msRest.ServiceCallback<Models.EmailRecipient>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    addEmailRecipient(options: Models.EmailerAddEmailRecipientOptionalParams, callback: msRest.ServiceCallback<Models.EmailRecipient>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<Models.UpdateEmailRecipientResponse>
     */
    updateEmailRecipient(options?: Models.EmailerUpdateEmailRecipientOptionalParams): Promise<Models.UpdateEmailRecipientResponse>;
    /**
     * @param callback The callback
     */
    updateEmailRecipient(callback: msRest.ServiceCallback<Models.EmailRecipient>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    updateEmailRecipient(options: Models.EmailerUpdateEmailRecipientOptionalParams, callback: msRest.ServiceCallback<Models.EmailRecipient>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<msRest.RestResponse>
     */
    deleteEmailRecipient(options?: Models.EmailerDeleteEmailRecipientOptionalParams): Promise<msRest.RestResponse>;
    /**
     * @param callback The callback
     */
    deleteEmailRecipient(callback: msRest.ServiceCallback<void>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    deleteEmailRecipient(options: Models.EmailerDeleteEmailRecipientOptionalParams, callback: msRest.ServiceCallback<void>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<Models.GetTemplatesResponse>
     */
    getTemplates(options?: msRest.RequestOptionsBase): Promise<Models.GetTemplatesResponse>;
    /**
     * @param callback The callback
     */
    getTemplates(callback: msRest.ServiceCallback<Models.Template[]>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    getTemplates(options: msRest.RequestOptionsBase, callback: msRest.ServiceCallback<Models.Template[]>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<Models.AddTemplateResponse>
     */
    addTemplate(options?: Models.EmailerAddTemplateOptionalParams): Promise<Models.AddTemplateResponse>;
    /**
     * @param callback The callback
     */
    addTemplate(callback: msRest.ServiceCallback<Models.Template>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    addTemplate(options: Models.EmailerAddTemplateOptionalParams, callback: msRest.ServiceCallback<Models.Template>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<Models.UpdateTemplateResponse>
     */
    updateTemplate(options?: Models.EmailerUpdateTemplateOptionalParams): Promise<Models.UpdateTemplateResponse>;
    /**
     * @param callback The callback
     */
    updateTemplate(callback: msRest.ServiceCallback<Models.Template>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    updateTemplate(options: Models.EmailerUpdateTemplateOptionalParams, callback: msRest.ServiceCallback<Models.Template>): void;
    /**
     * @param [options] The optional parameters
     * @returns Promise<msRest.RestResponse>
     */
    deleteTemplate(options?: Models.EmailerDeleteTemplateOptionalParams): Promise<msRest.RestResponse>;
    /**
     * @param callback The callback
     */
    deleteTemplate(callback: msRest.ServiceCallback<void>): void;
    /**
     * @param options The optional parameters
     * @param callback The callback
     */
    deleteTemplate(options: Models.EmailerDeleteTemplateOptionalParams, callback: msRest.ServiceCallback<void>): void;
}
export { Emailer, EmailerContext, Models as EmailerModels, Mappers as EmailerMappers };
