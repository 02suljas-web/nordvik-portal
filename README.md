# Nordvik Fastigheter AB – Hyresgästportal

Detta projekt är en Azure-baserad hyresgästportal för Nordvik Fastigheter AB.

## Funktioner
- Hyresgäster kan registrera felanmälningar.
- Felanmälan innehåller rubrik, kategori, beskrivning och bild.
- Bilder lagras i Azure Blob Storage.
- Blob-containern är privat och anonym åtkomst är inte tillåten.
- Azure App Service använder Managed Identity för åtkomst till lagringen.
- Åtkomst till Blob Storage styrs med Azure RBAC.
- Microsoft Entra ID används för autentisering.
- Power Automate används för notifiering vid nya felanmälningar.
- SharePoint används för hantering av felanmälningar.

## Azure-resurser
- Azure App Service
- Azure Storage / Blob Storage
- Managed Identity
- Azure RBAC
- Microsoft Entra ID
- Power Automate
- SharePoint

## Infrastructure as Code
Filen `azuredeploy.json` innehåller en ARM-template för Azure-resurserna.

## Säkerhet
Lösningen använder autentisering, Managed Identity, RBAC och privat Blob Storage för att skydda data.
