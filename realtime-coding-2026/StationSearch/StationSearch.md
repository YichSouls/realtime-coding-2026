# You are asked to write a small API to support the user interface of a train ticket machine

You will not be creating any actual User Interface but instead, you should model the problem space and implement a search feature to help the user find train stations by name in order to buy a ticket.

These machines have a direct but unreliable connection to the central system and use a touchscreen display which works as follows.

As the user types each character of the station's name on the touchscreen, the display should:

1. Update to show all valid choices for the next character
2. List of possible matching stations.

The illustration below shows what is needed when 'D A R T' has been entered.

[

  {
    "stationCode": "DRF",
    "stationName": "Dartford"
  },
  {
    "stationCode": "DRT",
    "stationName": "Darton"
  },
  {
    "stationCode": "LVC",
    "stationName": "Liverpool Central"  },
  {
    "stationCode": "LVJ",
    "stationName": "Liverpool James Street"
  },
  {
    "stationCode": "LIV",
    "stationName": "Liverpool Lime Street"
  },
  {
    "stationCode": "LPY",
    "stationName": "Liverpool South Parkway"
  }
]

## Requirements

-------------

1. Typing a search string will return:
    1. All stations that start with the search string.
    2. All valid next characters for each matched station.
2. Space is a valid character when returning a list of next characters.
3. The service response will be used for the machine UI and for the routing and pricing purposes.
