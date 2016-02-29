DECLARE @location_santoDomingo_name VARCHAR(500) = 'Santo Domingo, Dominican Republic'
DECLARE @location_santoDomingo_place_id VARCHAR(500) = 'ChIJv1lxQpuIr44ReFKkIVytlTE'
DECLARE @location_santoDomingo_latitude VARCHAR(500) = '18.5261268'
DECLARE @location_santoDomingo_longitude VARCHAR(500) = '-69.8835651'

DECLARE @location_santiago_name VARCHAR(500) = 'Santiago De Los Caballeros, Dominican Republic'
DECLARE @location_santiago_place_id VARCHAR(500) = 'ChIJn4nlOMjFsY4RKYR2uFmw1HU'
DECLARE @location_santiago_latitude VARCHAR(500) = '19.4791963'
DECLARE @location_santiago_longitude VARCHAR(500) = '-70.69305680000002'

DECLARE @santoDomingo_location_id INT = 1
DECLARE @santiago_location_id INT = 2

DECLARE @jobopportunity_id INT
DECLARE @location_id INT

DECLARE @current_jobopportunity_location_id INT

DECLARE job_opportunities_cursor CURSOR FOR  
SELECT JobOpportunityId, LocationId
FROM JobOpportunities
WHERE LocationId IN (@santoDomingo_location_id, @santiago_location_id)  

OPEN job_opportunities_cursor   
FETCH NEXT FROM db_cursor INTO @jobopportunity_id, @location_id   

BEGIN TRANSACTION
BEGIN TRY

	WHILE @@FETCH_STATUS = 0   
	BEGIN	
		IF(@location_id = @santiago_location_id)
		BEGIN
			INSERT INTO JobOpportunityLocations(Name, PlaceId, Latitude, Longitude)
			VALUES(@location_santiago_name, @location_santiago_place_id, @location_santiago_latitude, @location_santiago_longitude)
		END
		ELSE
		BEGIN
			INSERT INTO JobOpportunityLocations(Name, PlaceId, Latitude, Longitude)
			VALUES(@location_santoDomingo_name, @location_santoDomingo_place_id, @location_santoDomingo_latitude, @location_santoDomingo_longitude)
		END
	
		SELECT @current_jobopportunity_location_id = SCOPE_IDENTITY()

		UPDATE JobOpportunities SET JobOpportunityLocationId = @current_jobopportunity_location_id	
		WHERE JobOpportunityId = @jobopportunity_id
		
		FETCH NEXT FROM db_cursor INTO @jobopportunity_id, @location_id 
	END

	COMMIT TRAN

END TRY
BEGIN CATCH

	ROLLBACK

END CATCH

CLOSE job_opportunities_cursor   
DEALLOCATE job_opportunities_cursor










 