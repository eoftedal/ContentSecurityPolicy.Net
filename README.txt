Goal:
-----
- Allow the specification of the content security policy as a part of web.config
- Allow the policy to be used as an HttpModule so there is no need to add to pages etc. to enable it

Testing
-------
Verified via webtest project so far:
	img-src, object-src, script-src, style-src, frame-src

Web.config policy:
------------------
  <contentSecurityPolicy reportOnly="true" reportUri="csp-reporting/">
    <options allowInlineScript="true" />
    <allowedSources allowSelf="true" />
    <allowedImageSources>
      <add source="*" />
    </allowedImageSources>
    <allowedScriptSources allowSelf="true">
      <add source="*.google.com" />
    </allowedScriptSources>
  </contentSecurityPolicy>

Web.config for HttpModule:
--------------------------
      <httpModules>
        <add name="ContentSecurityPolicyHttpModule" type="ContentSecurityPolicy.Net.PolicyHttpModule, ContentSecurityPolicy.Net"/>
      </httpModules>


Abstract HTTP handler for receiving CSP failure reports
-------------------------------------------------------
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
