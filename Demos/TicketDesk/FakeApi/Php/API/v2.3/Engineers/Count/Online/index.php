<?php
	//check rate limiting
	$rateLimitFile = 'ratelimit.txt';
	$rateLimit = 1;
	$rateDelay = 10;
	$previousHit = file_get_contents($rateLimitFile);
	$currentHit = time();
	
	if($currentHit - $previousHit < $rateLimit)
	{
		sleep($rateDelay);
		header("X-RateLimit-Throttled: API request rate too high - {$rateDelay} second penalty imposed.");
	}
	
	file_put_contents($rateLimitFile, $currentHit, LOCK_EX);
	
	//Finally, send some data
	$engineers = rand(5, 7);
	echo($engineers);
?>