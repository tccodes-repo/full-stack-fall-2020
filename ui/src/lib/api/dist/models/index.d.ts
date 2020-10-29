import { ServiceClientOptions } from "@azure/ms-rest-js";
import * as msRest from "@azure/ms-rest-js";
/**
 * An interface representing Customer.
 */
export interface Customer {
    id?: string;
    firstName?: string;
    lastName?: string;
    email?: string;
}
/**
 * An interface representing EmailBlast.
 */
export interface EmailBlast {
    id?: string;
    customer?: string;
    template?: string;
    status?: string;
    emailsDelivered?: number;
    createdOn?: Date;
    statusChangedOn?: Date;
}
/**
 * An interface representing EmailRecipient.
 */
export interface EmailRecipient {
    id?: string;
    name?: string;
    email?: string;
    customer?: string;
}
/**
 * An interface representing Template.
 */
export interface Template {
    id?: string;
    name?: string;
    body?: string;
}
/**
 * An interface representing EmailerOptions.
 */
export interface EmailerOptions extends ServiceClientOptions {
    baseUri?: string;
}
/**
 * Optional Parameters.
 */
export interface EmailerAddCustomerOptionalParams extends msRest.RequestOptionsBase {
    body?: Customer;
}
/**
 * Optional Parameters.
 */
export interface EmailerUpdateCustomerOptionalParams extends msRest.RequestOptionsBase {
    body?: Customer;
}
/**
 * Optional Parameters.
 */
export interface EmailerDeleteCustomerOptionalParams extends msRest.RequestOptionsBase {
    body?: Customer;
}
/**
 * Optional Parameters.
 */
export interface EmailerAddEmailBlastOptionalParams extends msRest.RequestOptionsBase {
    body?: EmailBlast;
}
/**
 * Optional Parameters.
 */
export interface EmailerUpdateEmailBlastOptionalParams extends msRest.RequestOptionsBase {
    body?: EmailBlast;
}
/**
 * Optional Parameters.
 */
export interface EmailerAddEmailRecipientOptionalParams extends msRest.RequestOptionsBase {
    body?: EmailRecipient;
}
/**
 * Optional Parameters.
 */
export interface EmailerUpdateEmailRecipientOptionalParams extends msRest.RequestOptionsBase {
    body?: EmailRecipient;
}
/**
 * Optional Parameters.
 */
export interface EmailerDeleteEmailRecipientOptionalParams extends msRest.RequestOptionsBase {
    body?: EmailRecipient;
}
/**
 * Optional Parameters.
 */
export interface EmailerAddTemplateOptionalParams extends msRest.RequestOptionsBase {
    body?: Template;
}
/**
 * Optional Parameters.
 */
export interface EmailerUpdateTemplateOptionalParams extends msRest.RequestOptionsBase {
    body?: Template;
}
/**
 * Optional Parameters.
 */
export interface EmailerDeleteTemplateOptionalParams extends msRest.RequestOptionsBase {
    id?: string;
}
/**
 * Contains response data for the getCustomers operation.
 */
export declare type GetCustomersResponse = Array<Customer> & {
    /**
     * The underlying HTTP response.
     */
    _response: msRest.HttpResponse & {
        /**
         * The response body as text (string format)
         */
        bodyAsText: string;
        /**
         * The response body as parsed JSON or XML
         */
        parsedBody: Customer[];
    };
};
/**
 * Contains response data for the addCustomer operation.
 */
export declare type AddCustomerResponse = Customer & {
    /**
     * The underlying HTTP response.
     */
    _response: msRest.HttpResponse & {
        /**
         * The response body as text (string format)
         */
        bodyAsText: string;
        /**
         * The response body as parsed JSON or XML
         */
        parsedBody: Customer;
    };
};
/**
 * Contains response data for the updateCustomer operation.
 */
export declare type UpdateCustomerResponse = Customer & {
    /**
     * The underlying HTTP response.
     */
    _response: msRest.HttpResponse & {
        /**
         * The response body as text (string format)
         */
        bodyAsText: string;
        /**
         * The response body as parsed JSON or XML
         */
        parsedBody: Customer;
    };
};
/**
 * Contains response data for the getEmailBlasts operation.
 */
export declare type GetEmailBlastsResponse = Array<EmailBlast> & {
    /**
     * The underlying HTTP response.
     */
    _response: msRest.HttpResponse & {
        /**
         * The response body as text (string format)
         */
        bodyAsText: string;
        /**
         * The response body as parsed JSON or XML
         */
        parsedBody: EmailBlast[];
    };
};
/**
 * Contains response data for the addEmailBlast operation.
 */
export declare type AddEmailBlastResponse = EmailBlast & {
    /**
     * The underlying HTTP response.
     */
    _response: msRest.HttpResponse & {
        /**
         * The response body as text (string format)
         */
        bodyAsText: string;
        /**
         * The response body as parsed JSON or XML
         */
        parsedBody: EmailBlast;
    };
};
/**
 * Contains response data for the updateEmailBlast operation.
 */
export declare type UpdateEmailBlastResponse = EmailBlast & {
    /**
     * The underlying HTTP response.
     */
    _response: msRest.HttpResponse & {
        /**
         * The response body as text (string format)
         */
        bodyAsText: string;
        /**
         * The response body as parsed JSON or XML
         */
        parsedBody: EmailBlast;
    };
};
/**
 * Contains response data for the getEmailRecipients operation.
 */
export declare type GetEmailRecipientsResponse = Array<EmailRecipient> & {
    /**
     * The underlying HTTP response.
     */
    _response: msRest.HttpResponse & {
        /**
         * The response body as text (string format)
         */
        bodyAsText: string;
        /**
         * The response body as parsed JSON or XML
         */
        parsedBody: EmailRecipient[];
    };
};
/**
 * Contains response data for the addEmailRecipient operation.
 */
export declare type AddEmailRecipientResponse = EmailRecipient & {
    /**
     * The underlying HTTP response.
     */
    _response: msRest.HttpResponse & {
        /**
         * The response body as text (string format)
         */
        bodyAsText: string;
        /**
         * The response body as parsed JSON or XML
         */
        parsedBody: EmailRecipient;
    };
};
/**
 * Contains response data for the updateEmailRecipient operation.
 */
export declare type UpdateEmailRecipientResponse = EmailRecipient & {
    /**
     * The underlying HTTP response.
     */
    _response: msRest.HttpResponse & {
        /**
         * The response body as text (string format)
         */
        bodyAsText: string;
        /**
         * The response body as parsed JSON or XML
         */
        parsedBody: EmailRecipient;
    };
};
/**
 * Contains response data for the getTemplates operation.
 */
export declare type GetTemplatesResponse = Array<Template> & {
    /**
     * The underlying HTTP response.
     */
    _response: msRest.HttpResponse & {
        /**
         * The response body as text (string format)
         */
        bodyAsText: string;
        /**
         * The response body as parsed JSON or XML
         */
        parsedBody: Template[];
    };
};
/**
 * Contains response data for the addTemplate operation.
 */
export declare type AddTemplateResponse = Template & {
    /**
     * The underlying HTTP response.
     */
    _response: msRest.HttpResponse & {
        /**
         * The response body as text (string format)
         */
        bodyAsText: string;
        /**
         * The response body as parsed JSON or XML
         */
        parsedBody: Template;
    };
};
/**
 * Contains response data for the updateTemplate operation.
 */
export declare type UpdateTemplateResponse = Template & {
    /**
     * The underlying HTTP response.
     */
    _response: msRest.HttpResponse & {
        /**
         * The response body as text (string format)
         */
        bodyAsText: string;
        /**
         * The response body as parsed JSON or XML
         */
        parsedBody: Template;
    };
};
