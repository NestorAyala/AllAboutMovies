import axios, {AxiosResponse} from "axios";

// Flag to check if the interceptor is already set up
let isInterceptorSetup = false;

export const setupErrorHandlingInterceptor = () => {
    if (!isInterceptorSetup) {

        // Set up response interceptor for axios
        axios.interceptors.response.use(
            (response: AxiosResponse) => response,
            (error) => {
                if (error.response) {
                    const statusCode = error.response.statusCode;
                    const data = error.response.data;
                    
                    switch (statusCode){
                        case 400:
                            if (data.errors){
                                const modalStateErrors = [];
                                
                                for(const item of data.errors) {
                                    const property = item.property;
                                    const errorMessage = item.errorMessage;
                                    
                                    if (property && errorMessage) {
                                        modalStateErrors.push({property, errorMessage});
                                    }
                                }
                                
                                console.log(modalStateErrors);
                            }
                            
                            break;
                            
                        case 401:
                            console.log('Unauthorized');
                            break;
                            
                        case 403:
                            console.log('Forbidden');
                            break;
                            
                        case 404:
                            console.log('Not found');
                            break;
                            
                        default:
                            console.log('Some error');
                            break;
                    }
                }
                
                return Promise.reject(error);
            }
        )
        
        isInterceptorSetup = true;
    }
}