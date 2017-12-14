select c.CountryName,count(a.CountryCode) as CountOfAirports from tbAirport as a 
inner join tbCountry c on c.CountryCode = a.CountryCode
group by c.CountryName
order by count(a.CountryCode) desc
