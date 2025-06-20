import React from "react";
import "../styles/ServicesOverview.css";
import api from "../assets/api_integrate.jpg";
import easy from "../assets/easy-to-use.jpg";
import compare from "../assets/comparison.jpg";
import overview from "../assets/overview.jpg"

const ServicesOverview = () => {
  return (
    <section className="services-overview" id="services">
      {/* Platform Overview with Image */}
      <div className="overview-row">
        <div className="overview-text">
          <h2>Platform Overview</h2>
          <p>
            FarmSight is a solution that leverages satellite data and AI to:
          </p>
          <ul>
            <li>🧠 Monitor crop health</li>
            <li>📈 Predict yields</li>
            <li>⚠️ Detect anomalies & weather threats</li>
            <li>💬 Send real-time alerts via WhatsApp & SMS</li>
          </ul>
        </div>

        <div className="overview-image">
          <img src={overview} alt="Platform Overview" />
        </div>
      </div>


      {/* Data Sources */}
      <div className="datasource-block">
        <h2>Multiple Data Sources</h2>
        <div className="sources-grid">
          <div><strong>🛰️ Satellite</strong><p>Monitor large or remote areas</p></div>
          <div><strong>🌦️ Weather</strong><p>Smart crop calendars & forecasts</p></div>
          <div><strong>🧪 Soil</strong><p>Detect drought/overwatering conditions</p></div>
          <div><strong>📋 Field Scouting</strong><p>Real-time field-level journaling</p></div>
          <div><strong>📉 Yield</strong><p>Estimate productivity & harvests</p></div>
          <div><strong>📑 Reports</strong><p>Digital scouting reports for proactive action</p></div>
        </div>
      </div>

      {/* Platform Features */}
      <div className="features-summary">
        <h2>Platform Highlights</h2>
        <ul>
          <li>✅ NDVI Dashboards & Field Maps</li>
          <li>📅 12-Week Crop Trend Charts</li>
          <li>⚠️ Anomaly Alerts</li>
          <li>📱 WhatsApp/SMS Notifications</li>
          <li>🧠 Smart Crop Calendars & Yield Forecasting</li>
        </ul>
      </div>

      {/* Audience */}
      <div className="audience-block">
        <h2>Who This Is For</h2>
        <div className="audience-grid">
          <div><strong>🌱 Plant Specialists</strong><p>Improve yield while reducing input costs</p></div>
          <div><strong>🔬 Researchers</strong><p>Access reliable satellite and weather data</p></div>
          <div><strong>📦 Distributors</strong><p>Help optimize production and reduce waste</p></div>
          <div><strong>👨🏽‍🌾 Smallholder Farmers</strong><p>Make informed decisions with insights from space</p></div>
        </div>
      </div>
      {/* Platform Advantages */}
        <div className="advantages-block">
          <h2>Why Choose FarmSight?</h2>
          <div className="advantage-grid">
            <div>
              <img src={easy} alt="Easy Platform" />
            </div>
            <div>
              <img src={api} alt="API Integration" />
            </div>
          </div>
        </div>

        {/* Platform Comparison */}
        <div className="comparison-block">
          <h2>Rate our performance</h2>
          <img
            src={compare}
            alt="Platform Comparison Chart"
            className="compare-chart"
          />
        </div>
    </section>
  );
};

export default ServicesOverview;
