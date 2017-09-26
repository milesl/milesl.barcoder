# milesl.barcoder
Basic app for scanning and storing barcodes.

This app is seperated into the following components:
## Barcoder App
The barcoder app is a simple Angular app that utilises [QuaggaJS](https://serratus.github.io/quaggaJS) to scan barcodes and retrieve a list of barcodes from your device using the Barcoder Api.
## Barcoder Api
This barcoder api is a simple .NET Core WebApi that provides the following functionality:
* Accepts post requests to store scanned barcodes in the datasource
* Accepts get requests to return a list of stored barcodes from the datasource
