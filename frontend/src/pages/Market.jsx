import React, { useState, useEffect } from "react";
import RevenueChart from "../components/RevenueChart";
import "../styles/Market.css";

const Market = () => {
  /* ───────────── STATE ───────────── */
  const [crop, setCrop]       = useState("Fresh vegetables");
  const [region, setRegion]   = useState("Ghana");
  const [data, setData]       = useState(null);

  /* ──────────── FETCH / MOCK ──────────── */
  useEffect(() => {
    /* 👉 Replace this block with axios later */
    // Simulated backend payload:
    const mock = {
      years: [2018, 2019, 2020, 2021, 2022, 2023, 2024],
      revenue: [12, 14, 16, 17, 19, 22, 25],
      price:   [1.1, 1.2, 1.35, 1.45, 1.55, 1.7, 1.9],
      avgRev:  [120, 135, 147, 158, 170, 190, 210],
    };
    setData(mock);
  }, [crop, region]);

  if (!data) return <p style={{ padding: "2rem" }}>Loading …</p>;

  /* ───────────── RENDER ───────────── */
  return (
    <div className="market-page">
      {/*  TOP BAR  */}
      <div className="market-filters">
        <h1>Market Trends</h1>
        <select value={crop} onChange={(e) => setCrop(e.target.value)}>
          <option>Fresh vegetables</option>
          <option>Maize</option>
          <option>Cocoa</option>
        </select>

        <select value={region} onChange={(e) => setRegion(e.target.value)}>
          <option>Ghana</option>
          <option>Kenya</option>
          <option>Nigeria</option>
        </select>

        <button className="compare-btn">Compare Regions</button>
      </div>

      {/*  CHARTS GRID  */}
      <div className="market-grid">
        <div className="chart-card">
          <h4>Revenues</h4>
          <RevenueChart
            labels={data.years}
            values={data.revenue}
            color="#3f51b5"
            yLabel="Revenue (M USD)"
          />
        </div>

        <div className="chart-card">
          <h4>Average revenue&nbsp;per&nbsp;capita</h4>
          <RevenueChart
            labels={data.years}
            values={data.avgRev}
            color="#009688"
            yLabel="USD / person"
          />
        </div>

        <div className="chart-card">
          <h4>Prices</h4>
          <RevenueChart
            labels={data.years}
            values={data.price}
            color="#e64a19"
            yLabel="Price / kg"
          />
        </div>
      </div>
    </div>
  );
};

export default Market;
