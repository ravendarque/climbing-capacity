function GetCapacityData($name, $url) {
    $rawHtml = curl -s $url
    $capacityData = [Regex]::Match($rawHtml, "var data = ({.+?});").Groups[1].Value | ConvertFrom-Json -AsHashtable
    foreach ($centre in $capacityData.Keys) {
        Write-Host "$name-$($centre): $($capacityData[$centre].count) of $($capacityData[$centre].capacity)"
    }
    #return $capacityData
}

GetCapacityData "lcc" "https://portal.rockgympro.com/portal/public/a67951f8b19504c3fd14ef92ef27454d/occupancy?&iframeid=occupancyCounter&fId=2010"
GetCapacityData "yonder" "https://portal.rockgympro.com/portal/public/51b34d29708b17d6270dbfee783f7375/occupancy?&iframeid=occupancyCounter&fId="
GetCapacityData "thereach" "https://portal.rockgympro.com/portal/public/be94788ef672908b57b32977c18452dc/occupancy?&iframeid=occupancyCounter&fId="
GetCapacityData "climbinghangar" "https://portal.rockgympro.com/portal/public/8c5066575c2799fbf67b829828001c50/occupancy?&iframeid=occupancyCounter&fId="