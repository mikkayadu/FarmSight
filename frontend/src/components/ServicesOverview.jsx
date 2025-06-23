import React from "react";
import "../styles/ServicesOverview.css";
import api from "../assets/api_integrate.jpg";
import easy from "../assets/easy-to-use.jpg";
import compare from "../assets/comparison.jpg";
import crop from "../assets/crop yield.jpg"
import satellite from "../assets/satelite.jpg"
import report from "../assets/report.jpg"
import weather from "../assets/weater.jpg"
import scouting from "../assets/scouting.jpg"
import soil from "../assets/soil.jpg"

const ServicesOverview = () => {
  return (
      <section className="services-overview" id="services">
        <div className="overview-row">
          <div className="overview-text">
            <h2>Platform Overview</h2>
            <p>FarmSight leverages satellite data and AI to:</p>
            <ul>
              <li>🧠 Monitor crop health</li>
              <li>📈 Predict yields</li>
              <li>⚠️ Detect anomalies & weather threats</li>
              <li>💬 Send real-time alerts via WhatsApp & SMS</li>
            </ul>
          </div>

          <div className="vertical-divider"></div>

          <div className="impact-text">
            <h2>🌾Real-World Impact</h2>
            <p><strong>For Smallholder Farmers:</strong><br/>+10–30% yield boost, better decisions, income</p>
            <p><strong>For Extension Officers:</strong><br/>Better-targeted interventions</p>
            <p><strong>For Environment:</strong><br/>Encourages sustainable farming</p>
            <p><strong>Broader Impact:</strong><br/>Aligns with SDG 1, 2, 13</p>
          </div>
        </div>

        {/* Multiple Data Sources */}
      <div className="datasource-block">
        <h2>Multiple Data Sources</h2>
        <div className="sources-grid">
          <div className="source-card">
            <img src={satellite} alt="Satellite" />
            <h4>Satellite</h4>
            <p>Monitor large or remote areas</p>
          </div>
          <div className="source-card">
            <img src={weather} alt="Weather" />
            <h4>Weather</h4>
            <p>Smart crop calendars & forecasts</p>
          </div>
          <div className="source-card">
            <img src={soil} alt="Soil" />
            <h4>Soil</h4>
            <p>Detect drought/overwatering</p>
          </div>
          <div className="source-card">
            <img src={scouting} alt="Scouting" />
            <h4>Field Scouting</h4>
            <p>Real-time field-level journaling</p>
          </div>
          <div className="source-card">
            <img src={crop} alt="Yield" />
            <h4>Yield</h4>
            <p>Estimate productivity & harvests</p>
          </div>
          <div className="source-card">
            <img src={report} alt="Reports" />
            <h4>Reports</h4>
            <p>Scouting reports for proactive action</p>
          </div>
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
          <h2>Who This Is For?</h2>
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
              <img src={easy} alt="Easy Platform"/>
            </div>
            <div>
              <img src={api} alt="API Integration"/>
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
