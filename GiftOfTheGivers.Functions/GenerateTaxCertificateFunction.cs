using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using GiftOfTheGivers.Functions.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace GiftOfTheGivers.Functions
{
    public class GenerateTaxCertificateFunction
    {
        [Function("GenerateTaxCertificate")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "post",
                Route = "GenerateTaxCertificate"
            )]
            HttpRequestData req)
        {
            // -------------------------------------------------
            // 1. Create response object
            // -------------------------------------------------

            HttpResponseData response;

            try
            {
                // -------------------------------------------------
                // 2. Read JSON request body
                // -------------------------------------------------

                string requestBody =
                    await new StreamReader(req.Body).ReadToEndAsync();

                if (string.IsNullOrWhiteSpace(requestBody))
                {
                    response = req.CreateResponse(
                        System.Net.HttpStatusCode.BadRequest);

                    await response.WriteAsJsonAsync(new
                    {
                        success = false,
                        message = "Request body cannot be empty."
                    });

                    return response;
                }

                // -------------------------------------------------
                // 3. Deserialize request
                // -------------------------------------------------

                TaxCertificateRequest? request;

                try
                {
                    request = JsonSerializer.Deserialize<TaxCertificateRequest>(
                        requestBody,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                }
                catch (JsonException)
                {
                    response = req.CreateResponse(
                        System.Net.HttpStatusCode.BadRequest);

                    await response.WriteAsJsonAsync(new
                    {
                        success = false,
                        message = "Invalid JSON format."
                    });

                    return response;
                }

                // -------------------------------------------------
                // 4. Check that request exists
                // -------------------------------------------------

                if (request == null)
                {
                    response = req.CreateResponse(
                        System.Net.HttpStatusCode.BadRequest);

                    await response.WriteAsJsonAsync(new
                    {
                        success = false,
                        message = "Invalid request."
                    });

                    return response;
                }

                // -------------------------------------------------
                // 5. Validate request using DataAnnotations
                // -------------------------------------------------

                var validationResults =
                    new List<ValidationResult>();

                var validationContext =
                    new ValidationContext(request);

                bool isValid = Validator.TryValidateObject(
                    request,
                    validationContext,
                    validationResults,
                    validateAllProperties: true);

                if (!isValid)
                {
                    var errors = validationResults
                        .Select(x => x.ErrorMessage)
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToList();

                    response = req.CreateResponse(
                        System.Net.HttpStatusCode.BadRequest);

                    await response.WriteAsJsonAsync(new
                    {
                        success = false,
                        message = "Validation failed.",
                        errors = errors
                    });

                    return response;
                }

                // -------------------------------------------------
                // 6. Additional business validation
                // -------------------------------------------------

                string currency =
                    request.Currency.Trim().ToUpperInvariant();

                if (currency != "ZAR" &&
                    currency != "USD" &&
                    currency != "EUR")
                {
                    response = req.CreateResponse(
                        System.Net.HttpStatusCode.BadRequest);

                    await response.WriteAsJsonAsync(new
                    {
                        success = false,
                        message =
                            "Unsupported currency. " +
                            "The prototype supports ZAR, USD and EUR."
                    });

                    return response;
                }

                // -------------------------------------------------
                // 7. Clean donor name
                // -------------------------------------------------

                string donorName =
                    request.DonorName.Trim();

                // -------------------------------------------------
                // 8. Generate dummy certificate number
                // -------------------------------------------------

                string certificateNumber =
                    $"TAX-{DateTime.UtcNow:yyyyMMdd}-{request.DonationId}";

                // -------------------------------------------------
                // 9. Create response
                // -------------------------------------------------

                TaxCertificateResponse certificate =
                    new TaxCertificateResponse
                    {
                        Success = true,

                        CertificateNumber =
                            certificateNumber,

                        DonationId =
                            request.DonationId,

                        DonorName =
                            donorName,

                        Amount =
                            request.Amount,

                        Currency =
                            currency,

                        IssueDate =
                            DateTime.UtcNow,

                        Status =
                            "Generated",

                        Message =
                            "Dummy tax certificate generated " +
                            "successfully for prototype purposes."
                    };

                // -------------------------------------------------
                // 10. Return HTTP 200
                // -------------------------------------------------

                response = req.CreateResponse(
                    System.Net.HttpStatusCode.OK);

                await response.WriteAsJsonAsync(certificate);

                return response;
            }
            catch (Exception)
            {
                // -------------------------------------------------
                // 11. Handle unexpected errors
                // -------------------------------------------------

                response = req.CreateResponse(
                    System.Net.HttpStatusCode.InternalServerError);

                await response.WriteAsJsonAsync(new
                {
                    success = false,
                    message =
                        "An unexpected error occurred while " +
                        "generating the tax certificate."
                });

                return response;
            }
        }
    }
}