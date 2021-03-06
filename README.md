## Goal:
- 2012-08-28: Support the 1.0 version (but stay compatible with firefox) - This version *will break old configs* replacing options with allowedScriptSources unsafeAllowEval and unsafeAllowInline. allowedXhrSources is now allowedConnectSources
- 2011-09-29: Support the latest version from W3C, but stay compatible with firefox - adding 'unsafe-inline' and 'unsafe-eval'
- 2011-06-21: Support the latest version from W3C, but stay compatible with earlier versions in firefox and chrome
- 2011-06-15: Support the Chrome version as well, allthough this support is a bit experimental from Chrome's side
- Allow the specification of the content security policy as a part of web.config
- Allow the policy to be used as an HttpModule so there is no need to add to pages etc. to enable it

## Testing
Verified via webtest project so far:
	img-src, object-src, script-src, style-src, frame-src

## Web.config policy:
	<contentSecurityPolicy reportOnly="true" reportUri="csp-reporting/">
		<allowedSources allowSelf="true" unsafeAllowInline="true" />
		<allowedImageSources>
			<add source="*" />
		</allowedImageSources>
		<allowedScriptSources allowSelf="true" unsafeAllowEval="true">
			<add source="*.google.com" />
		</allowedScriptSources>
	</contentSecurityPolicy>

## Web.config for HttpModule:
	<httpModules>
		<add name="ContentSecurityPolicyHttpModule" type="ContentSecurityPolicy.Net.PolicyHttpModule, ContentSecurityPolicy.Net"/>
	</httpModules>


## Abstract HTTP handler for receiving CSP failure reports
Code for handler:

	public class ReportHandler : AbstractReportHandler
    {
        protected override void HandleReport(Report report)
        {
            //Store data here
        }
    }


Web.config policy definition for reportUri:

	<contentSecurityPolicy reportUri="csp-reporting/">


Web.config httphandler config:

	<httpHandlers>
		<add path="csp-reporting/" verb="POST" type="ContentSecurityPolicy.Net.WebTest.ReportHandler, ContentSecurityPolicy.Net.WebTest"/>
	</httpHandlers>
