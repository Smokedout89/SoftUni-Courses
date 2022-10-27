function roadRadar(kmPerHour, area) {
  let speedLimit;

  switch (area) {
    case `residential`:
      speedLimit = 20;
      break;
    case `city`:
      speedLimit = 50;
      break;
    case `interstate`:
      speedLimit = 90;
      break;
    case `motorway`:
      speedLimit = 130;
      break;
  }

  if (kmPerHour <= speedLimit) {
    console.log(`Driving ${kmPerHour} km/h in a ${speedLimit} zone`);
  } else {
    let difference = kmPerHour - speedLimit;
    let status;

    if (difference <= 20) {
      status = `speeding`;
    } else if (difference <= 40) {
      status = `excessive speeding`;
    } else {
      status = `reckless driving`;
    }

    console.log(
      `The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`
    );
  }
}

roadRadar(40, "city");
roadRadar(21, "residential");
roadRadar(120, "interstate");
roadRadar(200, "motorway");