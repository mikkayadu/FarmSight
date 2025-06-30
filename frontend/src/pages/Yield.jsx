// src/pages/YieldForecast.jsx
import React from "react";
import MiniCalendar from "../components/MiniCalendar";
import "../styles/Yield.css";
// import Footer from "../components/Footer.jsx";

const sampleData = [
  { crop: "Maize", sow: [0, 1], grow: [1, 5], harvest: [5, 6] },
  { crop: "Rice", sow: [2, 3], grow: [3, 6], harvest: [6, 7] },
  { crop: "Sorghum", sow: [1, 2], grow: [2, 5], harvest: [5, 6] },
  { crop: "Cowpea", sow: [3, 4], grow: [4, 6], harvest: [6, 7] },
];

const Yield = () => {
  return (
    <>
    <div className="yield-page">
      <div className="calendars">
        {[2024, 2025, 2026, 2027].map((year) => (
          <div key={year} className="calendar-card">
            <select defaultValue={year}>
              {[2024, 2025, 2026, 2027].map((y) => (
                <option key={y}>{y}</option>
              ))}
            </select>
            <MiniCalendar data={sampleData} />
          </div>
        ))}
      </div>

      <div className="sidebar-notes">
        <h4>Key Points <span>🗝️</span></h4>
        <p>
          <li>Maize yield likely to peak mid-year</li>
          <li>Rain delays may affect rice in July</li>
          <li>Sorghum ideal for early planting</li>
        </p>

        <h4>Recommended Crops / Plants <span>🌱</span></h4>
        <p>
          <li>Maize</li>
          <li>Sorghum</li>
          <li>Groundnut</li>
        </p>
      </div>
    </div>

    {/*<Footer/>*/}
    </>
  );
};

export default Yield;
