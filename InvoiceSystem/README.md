Invoice System API

This API provides endpoints for creating invoices, making payments, and processing overdue invoices.

Endpoints:

* POST /invoices: Create a new invoice
* GET /invoices: Get all invoices
* POST /invoices/{id}/payments: Make a payment on an invoice
* POST /invoices/process-overdue: Process overdue invoices

To run the API, use the following command:

`docker-compose up`

The API will be available at `http://localhost:8080`.