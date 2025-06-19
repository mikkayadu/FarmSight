import React from "react";
import "../styles/Legend.css";

const SoilDroughtIndex = () => {
  return (
    <div className="legend-container">
      <h4>💧 Soil Moisture & Drought Status</h4>

      <div className="strip-section">
        <div className="strip">
          <div className="strip-box" style={{ backgroundColor: "#e74c3c" }} />
          <div className="strip-box" style={{ backgroundColor: "#f39c12" }} />
          <div className="strip-box" style={{ backgroundColor: "#f1c40f" }} />
          <div className="strip-box" style={{ backgroundColor: "#27ae60" }} />
        </div>
        <p className="legend-labels">Dry — Moderate — Moist — Wet</p>
      </div>

      <div className="strip-section">
        <div className="strip">
          <div className="strip-box" style={{ backgroundColor: "#d73027" }} />
          <div className="strip-box" style={{ backgroundColor: "#fc8d59" }} />
          <div className="strip-box" style={{ backgroundColor: "#fee090" }} />
          <div className="strip-box" style={{ backgroundColor: "#91cf60" }} />
        </div>
        <p className="legend-labels">Severe — Mild — Weak — No Drought</p>
      </div>
    </div>
  );
};

export default SoilDroughtIndex;
