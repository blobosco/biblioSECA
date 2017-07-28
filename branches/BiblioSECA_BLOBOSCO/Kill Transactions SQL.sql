
DECLARE @spid INT,
			@cnt INT,
			@sql VARCHAR(255),
			@dbName VARCHAR(255)
	 
	SET @dbName = 'SEAC_CORE_ETAPA2_SADE_PREPROD';
	 
	SELECT @spid = MIN(spid), @cnt = COUNT(*)
		FROM master..sysprocesses
		WHERE dbid = DB_ID(@dbname)
		AND spid != @@SPID

	PRINT 'Starting to KILL '+RTRIM(@cnt)+' processes.'

	WHILE @spid IS NOT NULL
	BEGIN
		PRINT 'About to KILL '+RTRIM(@spid)  
		SET @sql = 'KILL '+RTRIM(@spid)
		EXEC(@sql)  
		SELECT @spid = MIN(spid), @cnt = COUNT(*)
			FROM master..sysprocesses
			WHERE dbid = DB_ID(@dbname)
			AND spid != @@SPID  
		PRINT RTRIM(@cnt)+' processes remain.'
	END
