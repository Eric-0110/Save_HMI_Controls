using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Save_HMI_Controls
{
    public partial class ModernDataGridView : UserControl
    {
        // 全类共用一个随机数实例，确保随机序列连续
        private Random _rnd = new Random();

        public ModernDataGridView()
        {
            InitializeComponent();

            // --- 使用通用方法一行代码初始化一个表格 ---

            // 1. 初始化 CNC 运行数据 (对象1)
            FillRandomData(modernDataGridView1, "编号,日期,时间,坐标,运行速度", (i) => new object[] {
                i.ToString("D4"),
                DateTime.Now.ToString("yyyy-MM-dd"),
                DateTime.Now.AddSeconds(i * 15).ToString("HH:mm:ss"),
                $"{(_rnd.NextDouble() * 100):F3}, {(_rnd.NextDouble() * 100):F3}",
                _rnd.Next(1200, 3000) + " mm/min"
            });

            // 2. 初始化 订单数据 (对象2)
            string[] products = { "工业伺服电机", "精密丝杠", "CNC主轴轴承", "导轨滑块", "传感器模块" };
            string[] orderStates = { "待支付", "生产中", "已发货", "已完成" };
            FillRandomData(modernDataGridView2, "订单号,商品名称,数量,单价,总价,状态", (i) => {
                int qty = _rnd.Next(1, 15);
                double price = _rnd.Next(500, 3000) + _rnd.NextDouble();
                return new object[] {
                    "ORD" + DateTime.Now.ToString("yyyyMMdd") + i.ToString("D3"),
                    products[_rnd.Next(products.Length)],
                    qty,
                    price.ToString("F2"),
                    (qty * price).ToString("F2"),
                    orderStates[_rnd.Next(orderStates.Length)]
                };
            });

            // 3. 初始化 运行状态数据 (对象3)
            string[] runStates = { "正常运行", "待机中", "设备报警", "紧急停止", "维护中" };
            FillRandomData(modernDataGridView3, "编号,日期,时间,坐标,运行状态", (i) => new object[] {
                i.ToString("D4"),
                DateTime.Now.ToString("yyyy-MM-dd"),
                DateTime.Now.AddMinutes(-i).ToString("HH:mm:ss"),
                $"{_rnd.Next(0, 800)}, {_rnd.Next(0, 600)}",
                runStates[_rnd.Next(runStates.Length)]
            });

            // 4. 初始化 对象4: 设备维护/报警记录 (4 列)
            string[] devices = { "主轴电机", "进给系统", "冷却泵", "润滑装置", "刀塔单元" };
            string[] results = { "已处理", "待检查", "组件更换", "正常" };

            FillRandomData(modernDataGridView4, "设备名称,维护日期,检测值,结果反馈", (i) => new object[] {
                devices[_rnd.Next(devices.Length)],             // 设备名称
                DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd"), // 维护日期
                $"{(_rnd.NextDouble() * 50 + 20):F2} ℃",          // 检测值 (模拟温度)
                results[_rnd.Next(results.Length)]               // 结果反馈
            });

            // 5. 初始化 对象5: 备件库存/物料清单 (6 列)
            string[] partNames = { "编码器单元", "联轴器 (10mm)", "液压密封圈", "继电器 (24V)", "感应开关", "丝杠润滑油" };
            string[] units = { "个", "套", "件", "支", "瓶" };

            FillRandomData(modernDataGridView5, "备件编码,名称规格,当前库存,单位,预警阈值,存放位置", (i) => {
                int stock = _rnd.Next(5, 100);
                int threshold = 20; // 预警阈值
                return new object[] {
                "SKU-" + _rnd.Next(1000, 9999),            // 备件编码
                partNames[_rnd.Next(partNames.Length)],     // 名称规格
                stock,                                      // 当前库存
                units[_rnd.Next(units.Length)],             // 单位
                threshold,                                  // 预警阈值
                "仓库-" + (char)('A' + _rnd.Next(0, 5)) + _rnd.Next(1, 10) // 存放位置 (如 A-1)
                };
            });

            // 6. 初始化 对象6: 系统报警日志 (3 列)
            string[] alarmLogs = { "伺服驱动器过载", "冷却液位过低", "紧急停止按钮按下", "主轴温度异常", "气压压力不足", "通信链路中断" };
            string[] levels = { "提示", "警告", "严重故障" };

            FillRandomData(modernDataGridView6, "记录时间,报警内容,级别", (i) => new object[] {
                DateTime.Now.AddSeconds(-i * 30).ToString("HH:mm:ss"), // 记录时间
                alarmLogs[_rnd.Next(alarmLogs.Length)],                // 报警内容
                levels[_rnd.Next(levels.Length)]                       // 级别
            });

            // 7. 初始化 对象7: 操作日志/审计追踪 (5 列)
            string[] operators = { "Admin", "Operator_01", "Engineer", "Manager" };
            string[] actions = { "修改参数", "启动设备", "停止设备", "配方下载", "清除报警", "导出报表" };
            string[] targets = { "压力阈值", "主轴转速", "进给倍率", "冷却开关", "生产工单" };

            FillRandomData(modernDataGridView7, "操作时间,操作员,动作类型,操作对象,备注信息", (i) => {
                string op = operators[_rnd.Next(operators.Length)];
                string act = actions[_rnd.Next(actions.Length)];
                string tgt = targets[_rnd.Next(targets.Length)];

                return new object[] {
                    DateTime.Now.AddMinutes(-i * 2).ToString("MM-dd HH:mm:ss"), // 操作时间
                    op,                                                         // 操作员
                    act,                                                        // 动作类型
                    tgt,                                                        // 操作对象
                    $"{op}成功执行了{act}操作"                                   // 备注信息
                };
            });

            // 7. 初始化 对象7: 多路参数监控 (6 列)
            // 序号, 通道, 温度, 压力, 占比, 转速
            FillRandomData(modernDataGridView8, "序号,通道,温度,压力,占比,转速", (i) => {
                // 模拟 1-8 号循环通道
                int channelId = (i - 1) % 8 + 1;
                double temp = 35.0 + _rnd.NextDouble() * 15.0; // 35-50度
                double press = 0.2 + _rnd.NextDouble() * 0.5;  // 0.2-0.7 MPa
                int ratio = _rnd.Next(60, 95);                 // 60%-95%
                int rpm = _rnd.Next(1500, 4500);               // 转速

                return new object[] {
                    i.ToString("D3"),                // 序号
                    $"CH-{channelId:D2}",            // 通道
                    temp.ToString("F1") + " ℃",      // 温度
                    press.ToString("F2") + " MPa",   // 压力
                    ratio + " %",                    // 占比
                    rpm + " RPM"                     // 转速
                };
            });

            // 9. 初始化 对象 9: 刀具管理/耗材寿命 (4 列)
            string[] toolNames = { "金刚石砂轮", "CBN 磨头", "R角成型刀", "粗磨砂轮", "精磨抛光轮" };
            string[] toolStates = { "使用中", "待更换", "预警中", "良好" };

            FillRandomData(modernDataGridView9, "刀具名称,已加工数,寿命上限,当前状态", (i) => {
                int maxLife = _rnd.Next(1000, 5000); // 寿命上限
                int currentLife = _rnd.Next(0, maxLife + 500); // 当前加工数，模拟可能超标
                string state = currentLife >= maxLife ? "待更换" : (currentLife > maxLife * 0.8 ? "预警中" : "良好");

                return new object[] {
                    toolNames[_rnd.Next(toolNames.Length)] + "-" + i.ToString("D2"), // 刀具名称
                    currentLife + " pcs",                                          // 已加工数
                    maxLife + " pcs",                                              // 寿命上限
                    state                                                          // 当前状态
                };
            });

            // 10. 初始化 对象10: 车间能耗与产出统计 (6 列)
            string[] lines = { "1号生产线", "2号生产线", "3号自动化线", "精密加工区", "组装车间" };

            FillRandomData(modernDataGridView10, "区域/线号,用电量,用水量,合格品,次品数,稼动率", (i) => {
                double power = 100 + _rnd.NextDouble() * 500;   // 模拟电量 kWh
                double water = 10 + _rnd.NextDouble() * 50;     // 模拟水量 m³
                int okCount = _rnd.Next(200, 1000);             // 合格品
                int ngCount = _rnd.Next(0, 15);                 // 次品
                double availability = 85 + _rnd.NextDouble() * 10; // 稼动率 85%-95%

                return new object[] {
                    lines[_rnd.Next(lines.Length)] + "-" + i.ToString("D2"), // 区域/线号
                    power.ToString("F1") + " kWh",                          // 用电量
                    water.ToString("F2") + " m³",                           // 用水量
                    okCount + " pcs",                                       // 合格品
                    ngCount + " pcs",                                       // 次品数
                    availability.ToString("F1") + " %"                      // 稼动率
                };
            });
        }

        /// <summary>
        /// 【通用数据填充工厂】
        /// 核心逻辑：解耦 UI 操作与数据生成逻辑
        /// </summary>
        /// <param name="dgv">目标 ModernDataGridView 控件</param>
        /// <param name="headers">逗号分隔的列名字符串</param>
        /// <param name="rowFactory">每一行数据的生成委托 (传入当前行号 i)</param>
        /// <param name="count">生成的总行数</param>
        private void FillRandomData(LYHControls.ModernDataGridView dgv, string headers, Func<int, object[]> rowFactory, int count = 40)
        {
            // 1. 设置列名
            dgv.QuickColumnHeaders = headers;

            // 2. 挂起布局，彻底防止添加过程中的重绘闪烁
            dgv.SuspendLayout();
            dgv.Rows.Clear();

            // 3. 循环填充数据
            for (int i = 1; i <= count; i++)
            {
                dgv.Rows.Add(rowFactory(i));
            }

            // 4. 恢复布局并刷新样式（确保行高、颜色、滚动条逻辑生效）
            dgv.ResumeLayout();
            dgv.UpdateStyle();
        }
    }
}