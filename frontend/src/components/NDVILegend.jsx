import React from "react";
import "../styles/Legend.css";

const NDVILegend = () => {
  const legendItems = [
    { color: "#d73027", label: "Bare Soil (0.0 - 0.2)" },
    { color: "#fee08b", label: "Low Vegetation (0.2 - 0.4)" },
    { color: "#1a9850", label: "Dense Vegetation (0.4 - 1.0)" },
  ];

  return (
    <div className="legend-container">
      <h4>🌈 NDVI Classes</h4>
      <div className="legend-items">
        {legendItems.map((item, index) => (
          <div key={index} className="legend-item">
            <span className="color-box" style={{ backgroundColor: item.color }}></span>
            <span>{item.label}</span>
          </div>
        ))}
      </div>
    </div>
  );
};

export default NDVILegend;
