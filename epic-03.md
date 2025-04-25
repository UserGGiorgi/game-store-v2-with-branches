# Epic 3 - Logging and Swagger


## General requirements

System should support the following features: 
* Inbound requests logging.  
* Error logging.  
* Swagger.   

Technical specifications:
* Use build-in logging infrastructure.  
* Use a global exception handler for error logging.  
* .txt files should be used as log storage.  
* A separate log file per day should be used.  

### E03 US1 - User story 1
Add Swagger infrastructure.
All endpoints should be accessible via the Swagger page.


### E03 US2 - User story 2
Create user-friendly response message in case of error.

## Non-functional requirement (Optional)
**E03 NFR1 **
       Create a middleware for logging request details, logs should include the user IP Address, target URL, response status code, request content, response content, and elapsed time.  

**E03 NFR2**
       Add exception details logging, logs should include the exception type, exception message, inner exceptions, exception details, stack trace.  

**E03 NFR3**
       Implement a logging in file to store all logs produced by the application. Use a separate file for exception logs.

**E03 NFR4\[optional\]**
       Add logs in main business layer methods.