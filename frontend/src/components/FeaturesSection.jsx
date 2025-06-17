import React from "react";
import "../styles/FeaturesSection.css";

const features = [
  {
    title: "NDVI Health Tracking",
    description: "Monitor vegetation health using EO satellite NDVI data to detect early signs of crop stress.",
  },
  {
    title: "Yield Forecasting",
    description: "Leverage AI models to estimate your farm's expected yield based on climate and crop trends.",
  },
  {
    title: "Anomaly Detection",
    description: "Get notified about unusual events like droughts, floods, or pest outbreaks in your location.",
  },
  {
    title: "Dynamic Crop Calendars",
    description: "Get smart calendars based on your crop and region — optimize planting and harvest times.",
  },
  {
    title: "WhatsApp / SMS Alerts",
    description: "Receive important alerts straight to your phone so you never miss a key event.",
  },
];

const FeaturesSection = () => {
  return (
    <div className="features-section">
      <h2>Core Features of FarmSight</h2>
      <div className="features-grid">
        {features.map((feat, idx) => (
          <div key={idx} className="feature-card">
            <h3>{feat.title}</h3>
            <p>{feat.description}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default FeaturesSection;
