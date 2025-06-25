import React, { useState, useEffect } from "react";
import "../styles/Insight.css";
import Footer from "../components/Footer.jsx";

const mockInsights = {
  ndvi: ["NDVI is stable for Field A", "Slight drop in Field B"],
  drought: ["No drought risk detected", "Monitor Field C for dryness"],
  climate: ["Rain expected next week", "High humidity in Field B"],
  recommendations: ["Irrigate Field B", "Harvest maize in Field A"]
};

const InsightSection = ({ title, data }) => {
  const [open, setOpen] = useState(false);

  return (
    <div className="insight-section">
      <div className="insight-header" onClick={() => setOpen(!open)}>
        <span className="dot" /> <strong>{title}</strong> {open ? "\u25B2" : "\u25BC"}
      </div>
      {open && (
        <ul className="insight-list">
          {data.map((item, index) => (
            <li key={index} className="insight-item">
              <span className="bullet" /> {item}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

const Insight = () => {
  const [insights, setInsights] = useState(null);

  useEffect(() => {
    // Simulate API call
    setTimeout(() => {
      setInsights(mockInsights);
    }, 500);

    // TODO: Replace with:
    // fetch('/api/insights', { headers: { Authorization: `Bearer ${token}` } })
    //   .then(res => res.json())
    //   .then(data => setInsights(data));
  }, []);

  return (
    <>
    <div className="farm-insight-page">
      <h2>Farm Insights</h2>
      {insights ? (
        <>
          <InsightSection title="NDVI" data={insights.ndvi} />
          <InsightSection title="Drought" data={insights.drought} />
          <InsightSection title="Climate" data={insights.climate} />
          <InsightSection title="Recommended Action" data={insights.recommendations} />
        </>
      ) : (
        <p>Loading insights...</p>
      )}
    </div>
    <Footer/>
    </>
  );
};

export default Insight;
