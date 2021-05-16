using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AnimationTrack : MonoBehaviour
{
    public Camera MainCamera;
    [Header("UI Related")] public GameObject MainCanvas;
    public GameObject ExplanationCanvas;
    public Image Panel;
    public TextMeshProUGUI CourseName;
    public TextMeshProUGUI ProjectName;
    public TextMeshProUGUI StudentName;
    public TextMeshProUGUI Explanation_1;
    public TextMeshProUGUI Explanation_2;

    public TextMeshProUGUI ExplanationVsCPU;
    public TextMeshProUGUI ExplanationVsGPU;
    public TextMeshProUGUI AnalogyText;

    [Header("CPU related")] public GameObject CPU;
    public GameObject BigCPU;
    public GameObject BigCPUCap;
    public GameObject[] BigCPUCoreCaps;
    public GameObject SmallCPU;

    [Header("GPU Related")] public GameObject GPU;
    public GPUTest BigGPU;
    public GameObject SmallGPU;

    [Header("Other")] public GameObject MotherBoard;

    [Header("Sprites")] public Image CPU_Architecture;
    public Image GPU_Architecture;

    [Header("Timer")] public TextMeshProUGUI Timer;
    [Header("Video")] public VideoPlayer videoPlayer;
    public RawImage videoUI;
    [Header("Audio")] public AudioSource audioPlayer;

    private bool RotateCPU;

    private float timer;

    private void Awake()
    {
        MainCanvas.SetActive(true);
        ExplanationCanvas.SetActive(false);
    }

    private IEnumerator Start()
    {
        audioPlayer.DOFade(1, 10f);
        yield return new WaitForSeconds(5f);
        Panel.DOFade(0, 1f);
        CourseName.DOFade(0, 1f);
        ProjectName.DOFade(0, 1f);
        StudentName.DOFade(0, 1f);
        yield return new WaitForSeconds(1f);

        ExplanationCanvas.SetActive(true);

        yield return new WaitForSeconds(4f);
        CPU.transform.DOMove(new Vector3(-10.3f, 2.33f, -0.77f), 2f);
        CPU.transform.DORotate(new Vector3(0, 135, 137.287f), 2f);
        GPU.transform.DOMove(new Vector3(-5.356212f, 2.083989f, -3.469464f), 2f);
        GPU.transform.DORotate(new Vector3(-142.301f, 45, 0), 2f);

        yield return new WaitForSeconds(2f);
        MotherBoard.transform.DOMove(new Vector3(13.44f, 0.51f, 18.92f), 5f);

        Explanation_1.text =
            "CPU and GPU\nTwo vital components of any computer mainly used today.\nWhat are the differences?";
        Explanation_1.DOFade(1, 1f);
        Panel.DOFade(0.75f, 1f);

        yield return new WaitForSeconds(4f);

        CPU.transform.DOMove(new Vector3(-7.61f, 1.72f, -4.38f), 1f);
        GPU.transform.DOMove(new Vector3(3.482f, 2.084f, -12.307f), 1f);

        Explanation_1.DOFade(0, 1f).OnComplete(() => Explanation_1.text = "");
        Panel.DOFade(0f, 1f);
        yield return new WaitForSeconds(2f);

        RotateCPU = true;

        CPU_Architecture.DOFade(1f, 1f);
        Explanation_1.text =
            "CPU (Central Processing Unit)\nIt is the brain of any computer or server.\nAny computer has at least one physical CPU, consisting 2 to 16 cores depending on the brand and model. " +
            "\nSome Server type CPUs might have even 128 cores (i.e. AMD ThreadRipper).";
        Explanation_1.DOFade(1, 1f);
        Panel.DOFade(0.75f, 1f);

        yield return new WaitForSeconds(7f);

        Explanation_1.DOFade(0, 1f).OnComplete(() => Explanation_1.text = "");
        Panel.DOFade(0f, 1f);
        yield return new WaitForSeconds(2f);
        Explanation_1.text = "Each core has speed of 2 to 4 GHz.";
        Explanation_1.DOFade(1, 1f);
        Panel.DOFade(0.75f, 1f);

        yield return new WaitForSeconds(7f);
        Explanation_1.DOFade(0, 1f).OnComplete(() => Explanation_1.text = "");
        Panel.DOFade(0f, 1f);
        CPU_Architecture.DOFade(0f, 1f);

        CPU.transform.DOMove(new Vector3(-13.69f, 1.72f, 1.91f), 1f);
        yield return new WaitForSeconds(1f);
        GPU.transform.DOMove(new Vector3(-6.857f, 1.627f, -4.357f), 1f);

        yield return new WaitForSeconds(2f);
        Explanation_1.text =
            "GPU (Graphics Processing Unit).\nIt's a type of processor chip specially designed for use on a graphics card. \nMost home computers has one, and specific workstations related to graphics" +
            " definitely has at least one.";
        Explanation_1.DOFade(1, 1f);
        Panel.DOFade(0.75f, 1f);
        yield return new WaitForSeconds(7f);
        Explanation_1.DOFade(0, 1f).OnComplete(() => Explanation_1.text = "");
        Panel.DOFade(0f, 1f);
        yield return new WaitForSeconds(2f);
        GPU_Architecture.DOFade(1, 1f);
        Explanation_1.text =
            "Modern GPUs have more than 3000 cores.\nHowever these cores have lower speed than CPUs, around 500-800 MHz";
        Explanation_1.DOFade(1, 1f);
        Panel.DOFade(0.75f, 1f);
        yield return new WaitForSeconds(7f);
        Explanation_1.DOFade(0, 1f).OnComplete(() => Explanation_1.text = "");
        Panel.DOFade(0f, 1f);
        GPU.transform.DOMove(new Vector3(3.482f, 2.084f, -12.307f), 1f);
        GPU_Architecture.DOFade(0, 1f);
        yield return new WaitForSeconds(1f);
        Explanation_2.text = "Let's take a closer look to CPU.";
        Explanation_2.DOFade(1, 1);
        yield return new WaitForSeconds(1f);

        GPU.SetActive(false);
        CPU.SetActive(false);
        MotherBoard.SetActive(false);

        BigCPU.transform.DOMove(new Vector3(-5.68f, 1.91f, 1f), 1f);
        MainCamera.transform.DOMove(new Vector3(-16.05f, 13.89f, -16.28f), 1f);
        Explanation_2.DOFade(0, 1);
        yield return new WaitForSeconds(5f);
        Explanation_2.text = "A typical CPU has 2 to 16 cores.";
        Explanation_2.DOFade(1, 1);
        BigCPUCap.transform.DOLocalMoveY(-1, 5f);
        yield return new WaitForSeconds(7f);
        Explanation_2.DOFade(0, 1).OnComplete(() => Explanation_2.text = "");
        foreach (var bigCPUCoreCap in BigCPUCoreCaps) bigCPUCoreCap.transform.DOLocalMoveY(15, 5f);
        yield return new WaitForSeconds(2f);
        Explanation_2.text = "On modern CPUs, each core has more than 1 BILLION Transistors.";
        Explanation_2.DOFade(1, 1);
        yield return new WaitForSeconds(7f);
        Explanation_2.DOFade(0, 1).OnComplete(() => Explanation_2.text = "");
        yield return new WaitForSeconds(2f);
        Explanation_2.text = "Now let's take a look at GPU.";
        BigCPU.transform.DOMove(new Vector3(35.73f, 0f, 50.16f), 1f).OnComplete(() => BigCPU.SetActive(false));
        Explanation_2.DOFade(1, 1);
        yield return new WaitForSeconds(2f);
        BigGPU.gameObject.SetActive(true);
        BigGPU.transform.DOMove(new Vector3(-5.29f, 0.5f, -4.74f), 1f);
        yield return new WaitForSeconds(2f);
        Explanation_2.DOFade(0, 1).OnComplete(() => Explanation_2.text = "");
        yield return new WaitForSeconds(2f);
        Explanation_2.text = "On modern GPUs, there are THOUSANDS of cores.";
        Explanation_2.DOFade(1, 1);
        BigGPU.MoveCapFrameUp(30);
        yield return new WaitForSeconds(7f);
        Explanation_2.DOFade(0, 1).OnComplete(() => Explanation_2.text = "");
        yield return new WaitForSeconds(2f);
        BigGPU.MoveCoreCaps(100);
        Explanation_2.text = "Each of these cores has more than 1 MILLION Transistors.";
        Explanation_2.DOFade(1, 1);
        yield return new WaitForSeconds(7f);
        Explanation_2.DOFade(0, 1).OnComplete(() => Explanation_2.text = "");
        BigGPU.transform.DOMove(new Vector3(44.01f, 0, -42.98f), 5f);
        yield return new WaitForSeconds(5f);
        BigGPU.gameObject.SetActive(false);
        MainCamera.transform.DOMove(new Vector3(-10.55f, 5.96f, -8.379f), 1f);
        yield return new WaitForSeconds(1f);
        SmallCPU.SetActive(true);
        SmallGPU.SetActive(true);
        yield return new WaitForSeconds(1f);

        Panel.DOFade(0.85f, 1f);
        ExplanationVsCPU.DOFade(1, 1f);
        ExplanationVsGPU.DOFade(1, 1f);
        yield return new WaitForSeconds(1f);
        ExplanationVsGPU.text = "";
        ExplanationVsCPU.text = "";

        var cpuText = "CPU\n" +
                      "- Less core count\n" +
                      "- More transistor per core\n" +
                      "- Less DATA parallelism power due to core count\n" +
                      "- High TASK parallelism due to core power\n" +
                      "- Better for serial instruction processing\n" +
                      "- Diverse instruction sets\n" +
                      "- Explicit Thread management\n" +
                      "- Context Switch Latency\n" +
                      "- High Memory\n" +
                      "- Very little surface area thus less core and transistor count in total\n" +
                      "- Low Latency emphasis\n";

        var gpuText = "GPU\n" +
                      "- Highly more core count\n" +
                      "- Less transistor per core\n" +
                      "- Very high DATA parallelism power due to core count\n" +
                      "- Less TASK parallelism due to core power\n" +
                      "- Better for parallel instruction processing\n" +
                      "- Less but highly optimized instruction sets\n" +
                      "- Threads are managed by hardware\n" +
                      "- No context switch\n" +
                      "- Less Memory\n" +
                      "- Very high surface area thus more core and transistor count in total\n" +
                      "- High Throughput emphasis\n";
        ExplanationVsCPU.DOText(cpuText, 20f);
        ExplanationVsGPU.DOText(gpuText, 20f);
        yield return new WaitForSeconds(10f);
        videoPlayer.Prepare();
        yield return new WaitForSeconds(10f);

        ExplanationVsCPU.DOFade(0, 1f);
        ExplanationVsGPU.DOFade(0, 1f);

        yield return new WaitForSeconds(1f);
        
        var analogy =
            "One way to visualize it is a CPU works like a small group of very smart people who can quickly do any " +
            "task given to them. " +
            "\n\nA GPU is a large group of relatively dumb people who aren't individually very fast " +
            "or smart, but who can be trained to do repetitive tasks, and collectively can be more productive just " +
            "due to the sheer number of people. " +
            "\n\nIt's not that a CPU is fat, spoiled, or lazy. " +
            "\n\nBoth CPUs and GPUs are creations made from billions of microscopic transistors crammed on a " +
            "small piece of silicon. On silicon chips, size is expensive. " +
            "\n\nThe structures that make CPUs good at what they do take up lots of space. " +
            "When those structures are omitted, that leaves plenty of room for " +
            "many 'dumb' ALU's, which individually are very small.";
        AnalogyText.DOText(analogy, 25f);
        yield return new WaitForSeconds(26f);

        AnalogyText.DOFade(0f, 1f);
        yield return new WaitForSeconds(1f);
        
        Explanation_2.text = "A video demonstration from MythBusters, endorsed by nVidia.";
        Explanation_2.DOFade(1, 1);
        yield return new WaitForSeconds(2f);
        audioPlayer.DOFade(0, 5f).OnComplete(() => audioPlayer.Stop());
        videoUI.enabled = true;
        videoPlayer.Play();
        Explanation_2.DOFade(0, 1);
        yield return new WaitForSeconds(15f);
        Explanation_2.text = "Notice CPU and GPU representation by the machines with Throughput and Parallelism.";
        Explanation_2.DOFade(1, 1);
        yield return new WaitForSeconds(15f);

        Explanation_2.DOFade(0, 1);
        yield return new WaitForSeconds(1f);
        Explanation_2.text = "CPU does sequential work, but is more powerful.";
        Explanation_2.DOFade(1, 1);
        yield return new WaitForSeconds(5f);

        Explanation_2.DOFade(0, 1);
        yield return new WaitForSeconds(15f);
        Explanation_2.text = "GPU does parallel work, but is less powerful.";
        Explanation_2.DOFade(1, 1);
        yield return new WaitForSeconds(5f);
        Explanation_2.DOFade(0, 1);

        yield return new WaitWhile(() => videoPlayer.isPlaying);
        Explanation_2.text = "This is how rendering works in modern computers.";
        Explanation_2.DOFade(1, 1);
        yield return new WaitForSeconds(2f);
        Explanation_2.DOFade(0, 1);
        yield return new WaitForSeconds(2f);
        Panel.DOFade(1, 1f);
        yield return new WaitForSeconds(1f);
        CourseName.DOFade(1, 1f);
        ProjectName.DOFade(1, 1f);
        StudentName.DOFade(1, 1f);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        var time = TimeSpan.FromSeconds(timer);

        Timer.text = time.ToString(@"hh\:mm\:ss\:fff");

        if (RotateCPU) CPU.transform.Rotate(Vector3.left * (Time.deltaTime * 50f));
    }
}