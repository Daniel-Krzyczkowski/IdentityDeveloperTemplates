![IdentityDeveloperTemplates.jpg](images/IdentityDeveloperTemplates.png)

# Introduction

## This project and repository was created to collect templates related to Microsoft Identity Platform and common authentication scenarios using best security practices.

![Code samples build](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/workflows/Code%20samples%20build/badge.svg)

![AD-B2C custom policies release](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/workflows/AD-B2C%20custom%20policies%20release/badge.svg)


*If you like this content, please give it a star!*
![github-start.png](images/github-start2.png)


## Below main chapters are covered (will be extended in the future):

#### [1. ASP. NET Core Razor Pages Web Application secured by Azure Active Directory](#asp-net-core-razor-pages-web-application-secured-by-azure-active-directory)
#### [2. ASP. NET Core Razor Pages Web Application secured by Azure Active Directory B2C](#asp-net-core-razor-pages-web-application-secured-by-azure-active-directory-b2c)
#### [3. ASP .NET Core Razor Pages web application secured by Azure Active Directory B2C with Authorization Data Storage](#asp-net-core-razor-pages-web-application-secured-by-azure-active-directory-b2c-with-Authorization-Data-Storage)
#### [4. ASP. NET Core Web API secured by Azure Active Directory](#asp-net-core-web-api-secured-by-azure-active-directory)
#### [5. ASP. NET Core Web API secured by Azure Active Directory with roles authorization](#asp-net-core-web-api-secured-by-azure-active-directory-with-groups-authorization)
#### [6. ASP. NET Core Web API secured by Azure Active Directory B2C](#asp-net-core-web-api-secured-by-azure-active-directory-b2c)
#### [7. UWP app secured by Azure Active Directory](#UWP-app-secured-by-azure-active-directory)
#### [8. UWP app secured by Azure Active Directory B2C](#UWP-app-secured-by-azure-active-directory)
#### [9. Azure Active Directory B2C generic templates with continuous delivery](#Azure-Active-Directory-B2C-generic-templates-with-continuous-delivery)
#### [10. Azure Active Directory B2C generic templates with MFA enabled](#Azure-Active-Directory-B2C-generic-templates-with-MFA-enabled)


# ASP. NET Core Razor Pages Web Application secured by Azure Active Directory

This code sample presents how to secure ASP .NET Core Razor Pages web application with Azure Active Directory. This sample uses [Microsoft Identity Web library](https://github.com/AzureAD/microsoft-identity-web).

### [Source code](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/tree/master/src/app-templates/IdentityDeveloperTemplates.AzureAD.WebApp)

# ASP. NET Core Razor Pages Web Application secured by Azure Active Directory B2C

This code sample presents how to secure ASP .NET Core Razor Pages web application with Azure Active Directory B2C. This sample uses [Microsoft Identity Web library](https://github.com/AzureAD/microsoft-identity-web).

### [Source code](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/tree/master/src/app-templates/IdentityDeveloperTemplates.AzureADB2C.WebApp)

# ASP. NET Core Web API secured by Azure Active Directory

This code sample presents how to secure ASP .NET Web API application with Azure Active Directory. This sample uses [Microsoft Identity Web library](https://github.com/AzureAD/microsoft-identity-web).

### [Source code](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/tree/master/src/app-templates/IdentityDeveloperTemplates.AzureAD.API)

# ASP. NET Core Razor Pages Web Application secured by Azure Active Directory B2C with Authorization Data Storage

This code sample presents how to secure ASP .NET Core Razor Pages web application with Azure Active Directory B2C with Authorization Data Storage. This sample uses [Microsoft Identity Web library](https://github.com/AzureAD/microsoft-identity-web).

This solution is described on [my tech blog](https://daniel-krzyczkowski.github.io/Azure-AD-B2C-With-External-Authorization-Store/).

### [Azure Functions source code](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/tree/master/src/app-templates/IdentityDeveloperTemplates.Authorization.Functions)

### [ASP .NET Core Razor Pages Web Application source code](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/tree/master/src/app-templates/IdentityDeveloperTemplates.AzureADB2C.WebApp)

# ASP. NET Core Web API secured by Azure Active Directory with roles authorization

This code sample presents how to secure ASP .NET Web API application with Azure Active Directory and use role authorization. This sample uses [Microsoft Identity Web library](https://github.com/AzureAD/microsoft-identity-web).

### [Source code](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/tree/master/src/app-templates/IdentityDeveloperTemplates.AzureAD.Authz.API)

# ASP. NET Core Web API secured by Azure Active Directory B2C

This code sample presents how to secure ASP .NET Core Razor Pages web application with Azure Active Directory B2C. This sample uses [Microsoft Identity Web library](https://github.com/AzureAD/microsoft-identity-web).

### [Source code](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/tree/master/src/app-templates/IdentityDeveloperTemplates.AzureADB2C.API)

# UWP app secured by Azure Active Directory

This code sample presents how to secure UWP application with Azure Active Directory. This sample uses [Microsoft Identity Client library](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet).

### [Source code](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/tree/master/src/app-templates/IdentityDeveloperTemplates.AzureAD.UWP)

# UWP app secured by Azure Active Directory B2C

This code sample presents how to secure UWP application with Azure Active Directory B2C. This sample uses [Microsoft Identity Client library](https://github.com/AzureAD/microsoft-authentication-library-for-dotnet).

### [Source code](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/tree/master/src/app-templates/IdentityDeveloperTemplates.AzureADB2C.UWP)

# Azure Active Directory B2C generic templates with continuous delivery

### [Source code](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/tree/master/src/ad-b2c-templates/ad-b2c-custom-policies-generic)

This sample presents how to create generic custom policies and setup continuous delivery for them using GitHub Actions.

This solution is described on [my tech blog](https://daniel-krzyczkowski.github.io/Automate-Azure-AD-B2C-policies-release-with-GitHub-Actions/).

# Azure Active Directory B2C generic templates with MFA enabled

This sample presents how to enable MFA for the Azure AD B2C custom policies.

### [Source code](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/tree/master/src/ad-b2c-templates/ad-b2c-custom-policies-mfa-enabled/custom-policies)

# Azure Function calling ASP .NET Core Web API secured by Azure AD B2C using client credentials flow

This sample presents how to send the request from the Azure Function App to ASP .NET Core Web API with access token obtained from the Azure AD B2C using client credentials flow.

### [Source code of Azure Function](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/tree/master/src/app-templates/IdentityDeveloperTemplates.ClientCredentialsAdB2C.FuncApp)

### [Source code of ASP .NET Core Web API](https://github.com/Daniel-Krzyczkowski/IdentityDeveloperTemplates/tree/master/src/app-templates/IdentityDeveloperTemplates.ClientCredentialsAdB2C.API)
