# This Microservice does the following:

# GET /api/supervisors

1. Reads data from an external API - WARNING!  ENDPOINT DOES NOT WORK
2. Filter out jurisdictions that are numeric
3. Sort data by jurisdiction, lastName, firstName
4. Convert data from external API, to a format of <jurisdiction> - <lastName>, <firstName>
5. Send the above as JSON data to the endpoint /api/supervisors

NOTES:  The Endpoint given https://o3m5qixdng.execute-api.us-east-1.amazonaws.com/api/managers has been offline.
FINALLY WORKS!

Mock Data was added incase endpoint fails again.

Requires: NuGet: "Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="8.0.4"

TODO for /api/supervisors:

	DONE!
	1.  Create a helper that gets the data from the above endpoint
		helper should be a singleton service

	DONE!
	2. Store the URI of the managers endpoint in appsettings.json (easier to change if needed).

	DONE!
	2.  Retrieve the data from the singleton service endpoint (but endpoint is flakey.  Mock Data is initialized incase endpoint fails.)

	DONE!
	3.  Manipulate the data (filter then sort, then change to List<string>)

	DONE!
	4.  Create a Supervisors Controller for the endpoint /api/supervisors, and serve the List<string> above as json

	DONE!
	Get rid of default Weather Forcast stuff.