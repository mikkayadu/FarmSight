import React from "react";
import "../styles/AboutUs.css";

const AboutUs = () => {
  return (
    <div className="about-container">
      <div className="about-card">
        <h1>About FarmSight</h1>
        <p>
          FarmSight is an intelligent platform designed to empower smallholder farmers across Sub-Saharan Africa with real-time insights from space.
          Using satellite Earth Observation data, AI, and predictive analytics, we help farmers track crop health, detect climate risks, and improve decisions.
        </p>
        <p>
          Whether you're planting maize in Tamale or managing cocoa fields in Kumasi, FarmSight gives you actionable insights — all in one smart dashboard.
        </p>
        <p>
          This platform was built as part of GAIAthon 2025, by a team of passionate innovators from the University of Ghana. We believe technology can drive a future of secure food systems, climate resilience, and empowered farming communities.
        </p>
      </div>
    </div>
  );
};

export default AboutUs;
